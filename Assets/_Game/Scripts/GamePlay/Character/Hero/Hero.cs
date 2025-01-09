using UnityEngine;

public class Hero : Character
{
    [Header("Target")]
    [SerializeField] private Zombie zombieTarget;
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
        if (zombieTarget.transform.position.x < transform.position.x)
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

    public virtual void DoDamageZombie()
    {

    }

    public virtual void DoDamageBus()
    {
       
    }
    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
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
    #endregion

    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}