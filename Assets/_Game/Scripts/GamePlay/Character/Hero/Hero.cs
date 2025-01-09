using UnityEngine;

public class Hero : Character
{
    protected IState_Hero currentState;

    [Header("Target")]
    [SerializeField] private bool canPaveTheWay;
    public bool CanPaveTheWay => canPaveTheWay;

    [SerializeField] private GameObject paveTheWayTarget;
    [SerializeField] private Zombie zombieTarget;
    public GameObject PaveTheWayTarget => paveTheWayTarget;
    public Zombie ZombieTarget => zombieTarget;

    [Header("Weapon - Gun")]
    private WeaponBase weaponBase;
    public WeaponBase WeaponBase => weaponBase;

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

    public override void CheckTargetDeath()
    {
        base.CheckTargetDeath();
        if (zombieTarget != null)
            if (zombieTarget.IsDeath)
                zombieTarget = null;
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
    }

    public void CheckAndSetCanAttackBus()
    {
        if (Vector3.Distance(paveTheWayTarget.transform.position, attackCheck.transform.position) < attackRadius)
            canPaveTheWay = true;
    }

    public void CheckDirX_SetZombieTarget()
    {
        if (zombieTarget.transform.position.x < transform.position.x)
            zombieTarget = null;
    }

    //get tat ca charactor trong attack
    public void GetSetZombie_InSeeRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTarget);
        if (hitColliders.Length > 0)
        {
            Zombie findTarget = null;
            float minDistance = float.MaxValue;

            foreach (var hit in hitColliders)
            {
                if (hit.transform.position.x > transform.position.x && minDistance > Vector3.Distance(hit.transform.position, transform.position))
                {
                    if (hit.TryGetComponent(out Zombie zombie))
                    {
                        if (zombie == null)
                            continue;
                        else
                        {
                            findTarget = zombie;
                            minDistance = Vector3.Distance(hit.transform.position, transform.position);
                        }
                    }
                }
            }
            zombieTarget = findTarget;
        }
        else
            zombieTarget = null;
    }

    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public void DoDamageZombie()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.position, attackRadius, whatIsTarget);

        if (hitColliders.Length <= 0)
            Debug.Log("Null Zombie In AttackRange");
        else
            foreach (var hit in hitColliders)
            {
                if (hit.TryGetComponent(out Zombie zombie))
                {
                    if (zombie == null)
                        continue;
                    zombie.OnHit(this.damage);
                    //Debug.Log("DoDamage: " + hit.gameObject.name);
                    //TODO: Knockback
                }
            }
    }

    public void DoDamageBus()
    {
        if (paveTheWayTarget != null)
        {
            //Todo: DODamage
            print("DoDamage paveTheWayTarget");
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

    #region State
    public void ChangeState(IState_Hero _newState)
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
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }
}