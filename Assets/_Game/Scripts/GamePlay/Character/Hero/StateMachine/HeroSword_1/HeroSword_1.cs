using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSword_1 : Hero
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

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        ChangeAnim("Death");
        capsuleCollider.enabled = false;
    }

    #endregion

    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new HeroSword_1_RutKiemState());
        ChangeAnim("RutKiem");
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}