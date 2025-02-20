using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(NavMeshAgent))]
public class Character : GameUnit
{

    //public Transform tf;//su dung thay cho tranform vi tranform = getComponent

    [SerializeField] private bool CanFindComponent_Auto = true;
    [SerializeField] Canvas_HealthBar healthBar;
    #region Component
    [Header("Component")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider BoxThisGameObject;
    [SerializeField] protected Animator animator;
    [Space(10)]
    [SerializeField] protected NavMeshAgent nav_Agent;
    // ...
    #endregion
    private string currentAnimName;

    [Header("Knock Back Info")]
    [SerializeField] protected float knockBackDistance;
    [SerializeField] protected float knockBackTimer;

    [Header("Idle Info")]
    [SerializeField] protected float startTime;

    [Header("Move Info")]
    [SerializeField] protected float speedMove;
    protected float speedMoveDefault;

    [Header("Stats Info")]
    [SerializeField] protected string nameCharactor;
    [SerializeField] protected float hp;
    protected float hpDefault;
    protected bool IsNoDamage;
    public bool IsDeath => hp <= 0;

    [Header("Layer Target")]
    [SerializeField] protected LayerMask whatIsTarget;

    [Header("Attack Info")]
    [SerializeField] protected int damage;
    [SerializeField] protected Transform attackCheck;
    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackCountdown = 2f;
    protected float lastTimeAttack;

    #region Base Unity

    protected virtual void OnValidate()
    {
        if (!CanFindComponent_Auto)
            return;
        //TF = transform;
        rb = GetComponent<Rigidbody>();
        BoxThisGameObject = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        nav_Agent = GetComponent<NavMeshAgent>();

        nav_Agent.speed = speedMove;

        if (rb == null || BoxThisGameObject == null || animator == null || nav_Agent == null)
            Debug.LogError("Null Component");
    }

    protected virtual void Awake()
    {
        speedMoveDefault = speedMove;
        hpDefault = hp;
    }

    protected virtual void Start()
    {
        OnInit();
    }

    protected virtual void Update()
    {
        //if (GameManager.Instance.GetGameState() != GameState.GamePlay)
        //{
        //    if (speedMove == speedMoveDefault)
        //        PauseGame();
        //}
        //else
        //{
        //    if (speedMove != speedMoveDefault)
        //        ContinueGame();
        //}
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.attackCheck.position, attackRadius);
    }

    #endregion

    #region Combat
    public bool CanAttackCoundown()
    {
        if (Time.time >= lastTimeAttack + attackCountdown)
            return true;

        return false;
    }

    public void ResetLastTimeAttack() => lastTimeAttack = Time.time;

    public virtual void Attack()
    {

    }

    public virtual void AttackCoundown()
    {

    }

    public virtual void CheckTargetDeath()
    {

    }
    public virtual void AttackSkillIndex(int _skillIndex)
    {

    }

    //check co charactor nao trong attack
    public virtual bool HaveCharater_InAttackRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.position, attackRadius, whatIsTarget);
        if (hitColliders.Length > 0)
            return true;
        else
            return false;
    }
    //check co charactor target trong attack
    public virtual bool HaveCharaterTarget_InAttackRadius()
    {
        return false;
    }

    public virtual bool HaveHowmTownOrCharacterInAttackCheck()
    {
        return false;
    }

    public virtual void DoDamage_HomeTownTarget()
    {

    }

    public virtual void OnHit(float damage)
    {
        //print(gameObject.name + "nhan : " + damage);
        if (IsNoDamage)
            return;

        if (!IsDeath)
        {
            hp -= damage;
            if (IsDeath)
            {
                hp = 0;
                OnDeath();
            }

            healthBar.SetNewHp(hp);
            //Instantiate(combatTextPrefabs, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }

    /// <summary>
    /// Knockback   
    /// </summary>
    /// <param name="character"> lay thong so knockback cua ZB khi danh nguoi choi va nguoc lai</param>
    /// <returns></returns>
    public IEnumerator IEKnockBack(Character character)
    {
        float timeCount = 0;
        print("knockback: " + gameObject.name);
        Vector3 startPoint = GetComponent<Transform>().position;
        Vector3 targetPoint = TF.position + character.transform.forward * character.knockBackDistance;

        while (timeCount < character.knockBackTimer)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            rb.position = Vector3.Lerp(startPoint, new Vector3(targetPoint.x, TF.position.y, targetPoint.z), timeCount / knockBackTimer);
            yield return null;
        }
    }

    protected virtual void OnDeath()
    {
        //gameObject.SetActive(false);
        OnStopMove();
        StopAllCoroutines();
        BoxThisGameObject.enabled = false;
        ChangeAnim(Constants.ANIM_DEATH);
    }
    #endregion

    #region Move

    public void SetDestination_Nav(Vector3 _point)
    {
        nav_Agent.SetDestination(_point);
    }

    public virtual void OnMoveToPoint(Vector3 _point)
    {
        ChangeAnim(Constants.ANIM_MOVE);

        SetDestination_Nav(_point);
    }

    public virtual void OnMoveToCharacterTarget()
    {

    }

    public virtual void OnStopMove()
    {
        ChangeAnim(Constants.ANIM_IDLE);
        SetDestination_Nav(TF.position);
    }

    public virtual void OnMoveToHomeTownTarget()
    {

    }

    #endregion

    public virtual void OnInit()
    {
        lastTimeAttack = Time.time;
        hp = hpDefault;
        speedMove = speedMoveDefault;

        BoxThisGameObject.enabled = true;

        healthBar.OnInit(hp);
    }
    public virtual void OnDesPawn()
    {
        //print("Pool");
        SimplePool.Despawn(this);
    }
    protected virtual void ChangeAnim(string _name)
    {
        if (currentAnimName != _name)
        {
            animator.ResetTrigger(currentAnimName);
            currentAnimName = _name;
            animator.SetTrigger(currentAnimName);
        }
    }

    public float GetIdleTime() => startTime;

    public IEnumerator IEMoveAndRotationToTarget(Vector3 _targetPoint, Quaternion _targetRot, float time)
    {
        float timeCount = 0;
        Vector3 startPoint = transform.position;
        Quaternion startRot = transform.rotation;

        ChangeAnim(Constants.ANIM_MOVE);
        while (timeCount < time)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            TF.position = Vector3.Lerp(startPoint, _targetPoint, timeCount / time);
            TF.rotation = Quaternion.Lerp(startRot, _targetRot, timeCount / time);
            yield return null;
        }
        ChangeAnim(Constants.ANIM_IDLE);
    }

    public void RotationToTarget(Transform _target)
    {
        Vector3 directionToTarget = (_target.position - TF.position).normalized;
        Quaternion targetRot = Quaternion.LookRotation(directionToTarget);

        TF.rotation = targetRot;
    }

    public IEnumerator IERotationToTarget(Transform _target, float time)
    {
        float timeCount = 0;
        Quaternion startRot = TF.rotation;
        Vector3 directionToTarget = (_target.position - TF.position).normalized;
        Quaternion _targetRot = Quaternion.LookRotation(directionToTarget);

        ChangeAnim(Constants.ANIM_MOVE);
        while (timeCount < time)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            TF.rotation = Quaternion.Lerp(startRot, _targetRot, timeCount / time);
            yield return null;
        }
        ChangeAnim(Constants.ANIM_IDLE);
    }

    /// <summary>
    /// chua xoay maat ve target thi false va xoay ve target
    /// </summary>
    /// <returns></returns>
    public bool CheckRotationToTarget_AndRotationIfFalse(Transform _target, float _speed)
    {
        Vector3 direction = _target.position - TF.position;
        direction.y = 0;

        float angleThreshold = 1f; // sai do goc cho phep
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        float angle = Quaternion.Angle(TF.rotation, targetRotation);

        if (direction != Vector3.zero)
            return true;

        if (angle > angleThreshold)
        {
            ChangeAnim(Constants.ANIM_MOVE);
            transform.rotation = Quaternion.RotateTowards(TF.rotation, targetRotation, _speed * Time.deltaTime);
            print("Dang quay");
            return false;
        }
        else
        {
            ChangeAnim(Constants.ANIM_IDLE);
            print("Quay xong");
            return true;
        }
    }

    public Vector3 GetRandomPointInCapsule()
    {
        Transform capsuleTransform = BoxThisGameObject.transform;
        Vector3 center = capsuleTransform.TransformPoint(BoxThisGameObject.center);
        float radius = BoxThisGameObject.radius;
        float halfHeight = Mathf.Max(0, BoxThisGameObject.height / 2f - radius);
        Vector3 up = capsuleTransform.up;

        Vector3 pointA = center + up * halfHeight;
        Vector3 pointB = center - up * halfHeight;

        Vector3 randomPointOnLine = Vector3.Lerp(pointA, pointB, Random.Range(0f, 1f));

        Vector3 randomOffset = Random.insideUnitSphere * radius;

        return randomPointOnLine + randomOffset;
    }

    public Vector3 GetTranformCapsual() => BoxThisGameObject.transform.position + BoxThisGameObject.transform.up * BoxThisGameObject.center.y;
}