using UnityEngine;

public class Hero_CloseCombat : Hero
{
    protected IState_HeroCloseCombat currentState;

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

        if (currentState != null && !IsDeath)
            currentState.OnExecute(this);
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
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
    }

    public override void CheckAndSetCanAttackBus()
    {
        base.CheckAndSetCanAttackBus();
        if (Vector3.Distance(thisBarrier.transform.position, attackCheck.transform.position) < attackRadius)
            canAttackBarrier = true;
    }

    public override void CheckDirX_SetZombieTarget()
    {
        base.CheckDirX_SetZombieTarget();
    }

    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public override void DoDamageZombie()
    {
        base.DoDamageZombie();
        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.position, attackRadius, whatIsTarget);

        if (hitColliders.Length <= 0)
        {
            //Debug.Log("Null Zombie In AttackRange");
        }
        else
            foreach (var hit in hitColliders)
            {
                if (hit.TryGetComponent(out Zombie zombie))
                {
                    if (zombie == null)
                        continue;
                    zombie.OnHit(this.damage);
                    //Debug.Log("DoDamage: " + hit.gameObject.name);
                    //TODO: Knockback
                }
            }
    }

    public override void DoDamage_HomeTownTarget()
    {
        base.DoDamage_HomeTownTarget();
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

    #region State
    public virtual void ChangeState(IState_HeroCloseCombat _newState)
    {
        if (currentState != null)
            currentState.OnExit(this);

        currentState = _newState;

        if (currentState != null)
            currentState.OnEnter(this);
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