using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider),typeof(NavMeshAgent))]
public class Character : GameUnit
{
    [SerializeField] private bool CanFindComponent_Auto = true;
    #region Component
    [Header("Component")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capsuleCollider;
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
    [SerializeField] protected float idleTime;

    [Header("Move Info")]
    [SerializeField] protected float speedMove;
    [SerializeField] protected float speedMoveDefault;

    [Header("Stats Info")]
    [SerializeField] protected string nameCharactor;
    [SerializeField] protected float hp;
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
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        nav_Agent = GetComponent<NavMeshAgent>();

        nav_Agent.speed = speedMove;

        if (rb == null || capsuleCollider == null || animator == null || nav_Agent == null)
            Debug.LogError("Null Component");
    }

    protected virtual void Awake()
    {

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

            //healthBar.SetNewHp(hp);
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
        Vector3 startPoint = transform.position;
        Vector3 targetPoint = transform.position + character.transform.forward * character.knockBackDistance;

        while (timeCount < character.knockBackTimer)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            rb.position = Vector3.Lerp(startPoint, new Vector3(targetPoint.x, transform.position.y, targetPoint.z), timeCount / knockBackTimer);
            yield return null;
        }
    }

    protected virtual void OnDeath()
    {
        //TODO:....
        //gameObject.SetActive(false);
        StopAllCoroutines();
        capsuleCollider.enabled = false;
        ChangeAnim(Constants.ANIM_DEATH);
    }
    IEnumerator IEWant(float _time)
    {
        yield return new WaitForSeconds(_time);
        SimplePool.Despawn(this);
    }
    #endregion

    #region Move

    public virtual void OnMoveToPoint(Vector3 _point)
    {
        ChangeAnim(Constants.ANIM_MOVE);
        nav_Agent.isStopped = false; 

        if (nav_Agent.destination != _point)
        {
            nav_Agent.SetDestination(_point);
        }
    }

    public virtual void OnStopMove()
    {
        ChangeAnim(Constants.ANIM_IDLE);
        nav_Agent.velocity = Vector3.zero;
        nav_Agent.isStopped = true;
    }

    public virtual void OnMoveToHomeTownTarget()
    {

    }

    #endregion

    public virtual void OnInit()
    {
        lastTimeAttack = Time.time;
        speedMoveDefault = speedMove;
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

    public float GetIdleTime() => idleTime;

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
            transform.position = Vector3.Lerp(startPoint, _targetPoint, timeCount / time);
            transform.rotation = Quaternion.Lerp(startRot, _targetRot, timeCount / time);
            yield return null;
        }
        ChangeAnim(Constants.ANIM_IDLE);
    }

    public void RotationToTarget (Transform _target)
    {
        Vector3 directionToTarget = (_target.position - transform.position).normalized;
        Quaternion targetRot = Quaternion.LookRotation(directionToTarget);

        transform.rotation = targetRot;
    }

    public IEnumerator IERotationToTarget(Transform _target, float time)
    {
        float timeCount = 0;
        Quaternion startRot = transform.rotation;
        Vector3 directionToTarget = (_target.position - transform.position).normalized; 
        Quaternion _targetRot = Quaternion.LookRotation(directionToTarget);

        ChangeAnim(Constants.ANIM_MOVE);
        while (timeCount < time)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRot, _targetRot, timeCount / time);
            yield return null;
        }
        ChangeAnim(Constants.ANIM_IDLE);
    }

    public Vector3 GetRandomPointInCapsule()
    {
        Transform capsuleTransform = capsuleCollider.transform;
        Vector3 center = capsuleTransform.TransformPoint(capsuleCollider.center);
        float radius = capsuleCollider.radius;
        float halfHeight = Mathf.Max(0, capsuleCollider.height / 2f - radius); 
        Vector3 up = capsuleTransform.up; 

        Vector3 pointA = center + up * halfHeight;
        Vector3 pointB = center - up * halfHeight;

        Vector3 randomPointOnLine = Vector3.Lerp(pointA, pointB, Random.Range(0f, 1f));

        Vector3 randomOffset = Random.insideUnitSphere * radius;

        return randomPointOnLine + randomOffset;
    }

    public Vector3 GetTranformCapsual()=> capsuleCollider.transform.position + capsuleCollider.transform.up * capsuleCollider.center.y;

    public virtual void PauseGame()
    {
        speedMove = 0;
        animator.speed = 0;
        nav_Agent.speed = speedMove;
    }
    
    public virtual void ContinueGame()
    {
        speedMove = speedMoveDefault;
        animator.speed = 1;
        nav_Agent.speed = speedMove;
    }
}