using System.Collections;
using UnityEngine;
public class Zombie : Character
{
    protected IState_Zombie currentState;

    [Header("Target")]
    [SerializeField] private bool canAttackBus;
    public bool CanAttackBus => canAttackBus;

    [SerializeField] private GameObject busTarget;
    [SerializeField] private Hero heroTarget;
    public GameObject BusTarget => busTarget;
    public Hero HeroTarget => heroTarget;

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

    public override void CheckTargetDeath()
    {
        base.CheckTargetDeath();
        if (heroTarget != null)
            if (heroTarget.IsDeath)
                heroTarget = null;
    }

    public void CheckAndSetCanAttackBus()
    {
        if (Vector3.Distance(busTarget.transform.position, attackCheck.transform.position) < attackRadius)
            canAttackBus = true;
    }

    public void CheckDirX_SetHeroTarget()
    {
        if (heroTarget.transform.position.x > transform.position.x)
            heroTarget = null;
    }

    //get tat ca hero trong tam thay va set target
    //public void GetSetHero_InSeeRadius()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTarget);
    //    if (hitColliders.Length > 0)
    //    {
    //        Hero findTarget = null;
    //        float minDistance = float.MaxValue;

    //        foreach (var hit in hitColliders)
    //        {
    //            if (hit.transform.position.x < transform.position.x && minDistance > Vector3.Distance(hit.transform.position, transform.position))
    //            {
    //                if (hit.TryGetComponent(out Hero hero))
    //                {
    //                    if (hero == null)
    //                        continue;
    //                    else
    //                    {
    //                        findTarget = hero;
    //                        minDistance = Vector3.Distance(hit.transform.position, transform.position);
    //                    }
    //                }
    //            }
    //        }
    //        heroTarget = findTarget;
    //    }
    //    else
    //        heroTarget = null;
    //}
    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public void DoDamageHero()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.position, attackRadius, whatIsTarget);

        if (hitColliders.Length <= 0)
            Debug.Log("Null Hero In AttackRange");
        else
            foreach (var hit in hitColliders)
            {
                if (hit.TryGetComponent(out Hero hero))
                {
                    if (hero == null)
                        continue;
                    hero.OnHit(this.damage);
                    //Debug.Log("DoDamage: " + hit.gameObject.name);
                    //TODO: Knockback
                }
            }
    }

    public void DoDamageBus()
    {
        if (busTarget != null)
        {
            //Todo: DODamage
            print("DoDamage Bus");
        }
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

    #region Move

    

    public override void OnMoveToPoint(Vector3 _point)
    {
        base.OnMoveToPoint(_point);
    }

    public override void OnStopMove()
    {
        base.OnStopMove();
    }

    #endregion

    #region ChangeState

    protected override void ChangeAnim(string _name)
    {
        base.ChangeAnim(_name);
    }

    public void ChangeState(IState_Zombie _newState)
    {
        if (currentState != null)
            currentState.OnExit(this);

        currentState = _newState;

        if (currentState != null)
            currentState.OnEnter(this);
    }
    #endregion

    public override void OnInit()
    {
        base.OnInit();
        canAttackBus = false;
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }

    #region Get -



    #endregion
}