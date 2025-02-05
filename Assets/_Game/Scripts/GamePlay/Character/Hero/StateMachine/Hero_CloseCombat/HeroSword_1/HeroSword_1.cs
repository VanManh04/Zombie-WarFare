public class HeroSword_1 : Hero_CloseCombat
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
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
        if (_skillIndex == 1)
        {
            //Chem 1 hit END: 1.496
            ChangeAnim("Attack1");
            Invoke(nameof(DoDamageZombie), 0.597f);
            if (canAttackBarrier)
                DoDamage_HomeTownTarget();
        }
        else if (_skillIndex == 2)
        {
            ChangeAnim("Attack2");
            //da thang END: 1.199
            Invoke(nameof(DoDamageZombie), 0.498f);
            if (canAttackBarrier)
                DoDamage_HomeTownTarget();
        }
        else
        {
            ChangeAnim("Attack3");
            //da xoay nguoi END: 1.731
            Invoke(nameof(DoDamageZombie), 0.6988f);
            if (canAttackBarrier)
                DoDamage_HomeTownTarget();
        }

    }

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        ChangeState(new HeroSword_1_DeathState());
        base.OnDeath();
    }

    #endregion

    public override void OnInit()
    {
        base.OnInit();
        ChangeAnim("RutKiem");
        ChangeState(new HeroSword_1_RutKiemState());
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}