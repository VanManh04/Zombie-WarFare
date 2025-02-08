using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Creep1 : Zombie
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
        //ChangeAnim(Constants.ANIM_ATTACK);
        //StartCoroutine(IEDoDamageAnimation());
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
        if (_skillIndex == 1)
        {
            ChangeAnim(Constants.ANIM_SKILL_1);
            StartCoroutine(IEDoDamageAnimation(.24f));
        }
        else
        {
            ChangeAnim(Constants.ANIM_SKILL_2);
            StartCoroutine(IEDoDamageAnimation(.09f));
            StartCoroutine(IEDoDamageAnimation(.16f));
        }
    }

    private IEnumerator IEDoDamageAnimation(float _time)
    {
        yield return new WaitForSeconds(_time);
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
        ChangeState(new Zombie_Death_Default());
        base.OnDeath();
    }

    protected override void ChangeAnim(string _name)
    {
        base.ChangeAnim(_name);
    }

    #endregion

    public override void OnInit()
    {
        base.OnInit();
        capsuleCollider.enabled = true;
        ChangeState(new Zombie_Creep1_Patrol());
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}