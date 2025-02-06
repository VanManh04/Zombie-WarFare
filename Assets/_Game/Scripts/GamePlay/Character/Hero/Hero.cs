using UnityEngine;

public class Hero : Character
{
    [Header("See Info")]
    [SerializeField] protected Transform seeCheck;
    [SerializeField] protected float seeRadius;

    [Header("Barrier")]
    [SerializeField] protected LayerMask whatIsBarrier;
    [SerializeField] protected Barrier thisBarrier;
    [SerializeField] protected bool canAttackBarrier;
    public bool CanAttackBarrier => canAttackBarrier;
    public Barrier ThisBarrier => thisBarrier;

    [Header("Target")]
    [SerializeField] protected Zombie zombieTarget;
    public Zombie ZombieTarget => zombieTarget;

    #region Base Unity

    protected override void OnValidate()
    {
        base.OnValidate();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.seeCheck.position, seeRadius);
    }

    #endregion

    #region Combat
    public override void Attack()
    {
        base.Attack();
    }

    public override void CheckTargetDeath()
    {
        base.CheckTargetDeath();

        if (zombieTarget != null)
            if (zombieTarget.IsDeath)
                zombieTarget = null;
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
    }

    public virtual void CheckAndSetCanAttackBus()
    {

    }

    public virtual void CheckDirX_SetZombieTarget()
    {
        if (zombieTarget != null && zombieTarget.transform.position.x < transform.position.x)
            zombieTarget = null;
    }

    //get tat ca charactor trong attack
    public virtual void GetSetZombie_InSeeRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTarget);
        if (hitColliders.Length > 0)
        {
            Zombie findTarget = null;
            float minDistance = float.MaxValue;

            foreach (var hit in hitColliders)
            {
                if (hit.transform.position.x > transform.position.x && minDistance > Vector3.Distance(hit.transform.position, transform.position))
                {
                    if (hit.TryGetComponent(out Zombie zombie))
                    {
                        if (zombie == null)
                            continue;
                        else
                        {
                            findTarget = zombie;
                            minDistance = Vector3.Distance(hit.transform.position, transform.position);
                        }
                    }
                }
            }
            zombieTarget = findTarget;
        }
        else
            zombieTarget = null;
    }

    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public override bool HaveHowmTownOrCharacterInAttackCheck()
    {
        bool haveCharacter = HaveCharater_InAttackRadius();
        bool haveBarrier;

        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.position, attackRadius, whatIsBarrier);
        if (hitColliders.Length > 0)
            haveBarrier = true;
        else
            haveBarrier = false;

        return haveCharacter || haveBarrier;
    }

    public override bool HaveCharaterTarget_InAttackRadius()
    {

        if (Vector3.Distance(attackCheck.transform.position, zombieTarget.transform.position) < attackRadius)
            return true;
        else
            return false;
    }

    public virtual void DoDamageZombie()
    {

    }

    public override void DoDamage_HomeTownTarget()
    {
        base.DoDamage_HomeTownTarget();
        if (thisBarrier != null && thisBarrier.gameObject.activeSelf)
            thisBarrier.OnHit(damage);
    }

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        ChangeAnim(Constants.ANIM_DEATH);
        capsuleCollider.enabled = false;
    }

    #endregion

    #region Move
    public override void OnMoveToPoint(Vector3 _point)
    {
        base.OnMoveToPoint(_point);
    }

    public override void OnStopMove()
    {
        base.OnStopMove();
    }

    public override void OnMoveToHomeTownTarget()
    {
        base.OnMoveToHomeTownTarget();

        ChangeAnim(Constants.ANIM_MOVE);
        nav_Agent.isStopped = false;

        Vector3 _point = transform.position;
        _point.x = thisBarrier.transform.position.x;

        if (nav_Agent.destination != _point)
        {
            nav_Agent.SetDestination(_point);
        }
    }
    #endregion

    public override void OnInit()
    {
        base.OnInit();
        capsuleCollider.enabled = true;
    }

    public void Setbarrier(Barrier barrier)
    {
        thisBarrier = barrier;
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }

    public bool SeeBarrier()
    {
        //Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTheWay);

        //if (hitColliders.Length > 0)
        if (thisBarrier == null)
            return false;

        Vector3 pointBarrier = seeCheck.position;
        pointBarrier.x = ThisBarrier.transform.position.x;

        if (Vector3.Distance(seeCheck.transform.position, pointBarrier) < seeRadius)
            return true;
        return false;


    }

    public void CheckCanAttackBarrier()
    {
        Vector3 pointBarrier = attackCheck.position;
        pointBarrier.x = ThisBarrier.transform.position.x;

        if (Vector3.Distance(attackCheck.position, pointBarrier) < attackRadius)
        {
            canAttackBarrier = true;
        }
    }
}