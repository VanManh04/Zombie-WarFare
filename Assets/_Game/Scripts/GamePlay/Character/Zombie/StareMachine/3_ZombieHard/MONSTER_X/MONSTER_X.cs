using System.Collections;
using UnityEngine;

public class MONSTER_X : Zombie
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

    public override void AttackCoundown()
    {
        base.AttackCoundown();
        ChangeAnim(Constants.ANIM_ATTACKCOUNDOWN);
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);

        if (_skillIndex == 1)
        {
            ChangeAnim(Constants.ANIM_SKILL_1);
            StartCoroutine(IEDoDamageAnimation(.43f));
            StartCoroutine(IEDoDamageAnimation(2.06f));
        }
        else
        {
            ChangeAnim(Constants.ANIM_SKILL_2);
            StartCoroutine(IEDoDamageAnimation(.34f));
        }
    }

    private IEnumerator IEDoDamageAnimation(float _timer)
    {
        yield return new WaitForSeconds(_timer);
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

    #endregion

    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new MONSTER_X_Patrol());
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}