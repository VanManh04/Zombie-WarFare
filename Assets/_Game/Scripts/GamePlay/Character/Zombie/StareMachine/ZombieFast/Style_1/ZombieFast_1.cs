using System.Collections;
using UnityEngine;

public class ZombieFast_1 : Zombie
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
        ChangeAnim("Attack");
        StartCoroutine(IEDoDamageAnimation());
    }

    private IEnumerator IEDoDamageAnimation()
    {
        yield return new WaitForSeconds(0.166f);
        if (CanAttackBus)
            DoDamage_HomeTownTarget();
        else
            DoDamageHero();

        yield return new WaitForSeconds(0.433f);
        if (CanAttackBus)
            DoDamage_HomeTownTarget();
        else
            DoDamageHero();
    }


    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        capsuleCollider.enabled = false;
        ChangeState(new DeathState_ZBFast_1());
    }

    #endregion

    public override void OnInit()
    {
        base.OnInit();
        capsuleCollider.enabled = true;
        ChangeState(new IdleState_ZBFast_1());
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}