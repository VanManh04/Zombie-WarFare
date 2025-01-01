using System.Collections;
using UnityEngine;

public class ZombieNormal_1 : Zombie
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

    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState_ZBNormal_1());
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}