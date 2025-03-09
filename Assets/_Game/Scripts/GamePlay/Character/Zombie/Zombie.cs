using UnityEngine;
public class Zombie : Character
{
    protected IState_Zombie currentState;
    [Header("See Info")]
    [SerializeField] protected Transform seeCheck;
    [SerializeField] protected float seeRadius;

    [Header("Target")]
    [SerializeField] private LayerMask whatIsBus;
    [SerializeField] private bool canAttackBus;
    public bool CanAttackBus => canAttackBus;

    [SerializeField] private Bus busTarget;
    [SerializeField] private Hero heroTarget;
    public Bus BusTarget => busTarget;
    public Hero HeroTarget => heroTarget;

    [SerializeField] int coinDeath;

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

        if (currentState != null)
            currentState.OnExecute(this);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.seeCheck.position, seeRadius);
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
        {
            canAttackBus = true;
        }
    }

    public bool CanTargetHero()
    {
        return Mathf.Abs(TF.position.x - busTarget.transform.position.x)>1.6f;
    }

    public void CheckDirX_SetHeroTarget()
    {
        if (heroTarget.transform.position.x > transform.position.x)
            heroTarget = null;
    }

    //get tat ca hero trong tam thay va set target
    public void GetSetHero_InSeeRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTarget);
        if (hitColliders.Length > 0)
        {
            Hero findTarget = null;
            float minDistance = float.MaxValue;

            foreach (var hit in hitColliders)
            {
                if (hit.transform.position.x < transform.position.x && minDistance > Vector3.Distance(hit.transform.position, transform.position))
                {
                    Hero hero = Cache.GenCollectHero(hit);
                        if (hero == null)
                            continue;
                        else
                        {
                            findTarget = hero;
                            minDistance = Vector3.Distance(hit.transform.position, transform.position);
                        }
                }
            }
            heroTarget = findTarget;
        }
        else
            heroTarget = null;
    }
    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public override bool HaveHowmTownOrCharacterInAttackCheck()
    {
        bool haveCharacter = HaveCharater_InAttackRadius();
        bool haveBus;

        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.transform.position, attackRadius, whatIsBus);
        if (hitColliders.Length > 0)
            haveBus = true;
        else
            haveBus = false;

        return haveCharacter || haveBus;
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
                    //Knockback
                }
            }
    }

    public override void DoDamage_HomeTownTarget()
    {
        base.DoDamage_HomeTownTarget();
        if (busTarget != null && busTarget.gameObject.activeSelf)
        {
            // DODamage
            //print("DoDamage Bus");
            busTarget.OnHit(this.damage);
        }
    }

    public override void OnHit(float damage)
    {
        base.OnHit(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        LevelManager.Instance.AddCoin(coinDeath);
    }
    #endregion


    #region Move

    public override void OnMoveToHomeTownTarget()
    {
        base.OnMoveToHomeTownTarget();

        ChangeAnim(Constants.ANIM_MOVE);
        nav_Agent.isStopped = false;

        Vector3 _point = busTarget.transform.position;

        if (nav_Agent.destination != _point)
        {
            nav_Agent.SetDestination(_point);
        }
    }

    public override void OnMoveToCharacterTarget()
    {
        base.OnMoveToCharacterTarget();
        ChangeAnim(Constants.ANIM_MOVE);

        Vector3 _point = heroTarget.TF.position;

        SetDestination_Nav(_point);
    }

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

    public virtual void ChangeState(IState_Zombie _newState)
    {
        //if (currentState != null)
        currentState?.OnExit(this);

        currentState = _newState;

        if (currentState != null)
            currentState.OnEnter(this);
    }
    #endregion

    public override void OnInit()
    {
        heroTarget = null;
        busTarget = LevelManager.Instance.GetBus;
        if (busTarget == null)
            OnDesPawn();
        base.OnInit();
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }

    public bool HeroTarget_Null_True()
    {
        return heroTarget == null;
    }

    public Transform GetTranformHeroTarget()
    {
        return heroTarget.transform;
    }
}