public class HeroSword_1_2 : Hero_CloseCombat
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
        if (this.poolType == (PoolType)HeroType.HeroSword_1)
        {
            if (_skillIndex == 1)
            {
                //Chem 1 hit END: 1.496
                ChangeAnim("Attack1");
                Invoke(nameof(DoDamageZombie), 0.597f);
                if (canAttackBarrier)
                    DoDamage_HomeTownTarget();
            }
            else
            {
                ChangeAnim("Attack2");
                //da thang END: 1.199
                Invoke(nameof(DoDamageZombie), 0.498f);
                if (canAttackBarrier)
                    DoDamage_HomeTownTarget();
            }
        }
        else
        {
            if (_skillIndex == 1)
            {
                //Chem 1 hit END: 1.496
                ChangeAnim("Attack1");
                Invoke(nameof(DoDamageZombie), 0.597f);
                if (canAttackBarrier)
                    DoDamage_HomeTownTarget();
            }
            else if(_skillIndex == 2)
            {
                ChangeAnim("Attack2");
                Invoke(nameof(DoDamageZombie), 1.25f);
                if (canAttackBarrier)
                    DoDamage_HomeTownTarget();
                //end 3.1f
            }
            else
            {
                ChangeAnim("Attack3");
                Invoke(nameof(DoDamageZombie), 1.02f);
                if (canAttackBarrier)
                    DoDamage_HomeTownTarget();
                //end 1.33
            }
        }

    }

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        ChangeState(new HeroCloseCombat_Death_Default());
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