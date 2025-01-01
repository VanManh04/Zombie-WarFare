using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] private bool CanFindComponent_Auto = true;
    [SerializeField] protected CharacterType characterType;
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

    [Header("Stats Info")]
    [SerializeField] protected string nameCharactor;
    [SerializeField] protected float hp;
    protected bool IsNoDamage;
    protected bool IsDeath => hp <= 0;

    [Header("Layer Target")]
    [SerializeField] protected LayerMask whatIsTarget;

    [Header("Attack Info")]
    [SerializeField] protected int damage;
    [SerializeField] protected Transform attackCheck;
    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackCountdown = 2f;


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
        if(Input.GetKeyUp(KeyCode.E))
            OnDrawGizmos();
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.attackCheck.position, attackRadius);
    }

    #endregion

    #region Combat
    public virtual void Attack()
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
    }
    #endregion

    public virtual void OnInit()
    {

    }
    public virtual void OnDesPawn()
    {

    }
    protected void ChangeAnim(string _name)
    {
        if (currentAnimName != _name)
        {
            animator.ResetTrigger(currentAnimName);
            currentAnimName = _name;
            animator.SetTrigger(currentAnimName);
        }
    }
}
