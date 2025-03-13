using System.Collections;
using UnityEngine;

public class Cyber_Monsters_2 : Zombie
{
    [SerializeField] Projectile bulletPrefabs;
    [SerializeField] Transform posSpawn;
    [SerializeField] float coundownAttackGun = 0f;

    float timer = 0f;
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
        timer -= Time.deltaTime;
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
            //sword
            ChangeAnim(Constants.ANIM_SKILL_1);
            StartCoroutine(IEDoDamageAnimation(.9f));
        }
        else
        {
            //gun
            AttackGun();
        }
    }

    public bool CanAttackGun()
    {
        return timer <= 0;
    }

    public void AttackGun()
    {
        timer = coundownAttackGun;
        ChangeAnim(Constants.ANIM_SKILL_2);
        //StartCoroutine(IEDoDamageAnimation(.12f));
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
        ChangeState(new CyberMonsters2_patrol());
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}