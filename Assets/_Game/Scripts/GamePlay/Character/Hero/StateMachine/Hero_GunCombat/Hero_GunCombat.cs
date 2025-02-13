using UnityEngine;


public class Hero_GunCombat : Hero
{
    protected IState_HeroGunCombat currentState;

    [Header("Weapon - Gun")]
    [SerializeField] protected WeaponBase weaponBase;
    public WeaponBase WeaponBase => weaponBase;

    [SerializeField] protected int amountOneCombatDefault;

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

        if (currentState != null)
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

    public virtual void Reload()
    {
        ChangeAnim(Constants.ANIM_RELOAD);
        //reload gun
    }

    public virtual bool OutOfAmmo()
    {
        return weaponBase.OutOfAmmo();
    }

    public override void GetSetZombie_InSeeRadius()
    {
        base.GetSetZombie_InSeeRadius();
    }

    public override void CheckTargetDeath()
    {
        base.CheckTargetDeath();
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
    }

    public override void CheckDirX_SetZombieTarget()
    {
        base.CheckDirX_SetZombieTarget();
    }

    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
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

    #region Wait Target

    public void WaitTarget_anim()
    {
        ChangeAnim(Constants.ANIM_WAITTARGET);
    }

    #endregion

    #region State
    public virtual void ChangeState(IState_HeroGunCombat _newState)
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