public class Hero_AKM : Hero_GunCombat
{
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
        ChangeAnim(Constants.ANIM_SHOOT);
        //weapon
        weaponBase.SetUpTarget(zombieTarget.GetTranformCapsual());
        weaponBase.Shoot(.35f);
    }

    public override void Reload()
    {
        base.Reload();
        ChangeAnim(Constants.ANIM_RELOAD);
        //weapon

        weaponBase.Reload();
    }

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        ChangeState(new HeroGunCombat_Death_Default());
        base.OnDeath();
    }
    #endregion

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }

    public override void OnInit()
    {
        base.OnInit();
        //setup amount gun
        this.weaponBase.SetUpAmountAnDamage(amountOneCombatDefault,damage);
        this.ChangeState(new Hero_AKM_Patrol());
    }
}