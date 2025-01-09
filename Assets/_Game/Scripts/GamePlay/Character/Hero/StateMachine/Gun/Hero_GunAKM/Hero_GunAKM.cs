public class Hero_GunAKM : Hero
{
    public override void Attack()
    {
        base.Attack();
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
    }

    public override void CheckTargetDeath()
    {
        base.CheckTargetDeath();
    }

    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    public override void OnInit()
    {
        base.OnInit();
    }
    #region Base Unity
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    protected override void OnValidate()
    {
        base.OnValidate();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    #endregion

    #region Combat

    #endregion

}