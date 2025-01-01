using UnityEngine;
public class Zombie : Character
{
    protected IState_Zombie currentState;

    [SerializeField] private Character target;
    public Character Target => target;
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

    public float DistanceAttackToTarget() => Vector3.Distance(target.transform.position, attackCheck.transform.position);

    public override void Attack()
    {
        base.Attack();
        print("Attack");
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

    public void OnMoveToPoint(Vector3 _point)
    {
        ChangeAnim("Walk");
        nav_Agent.isStopped = false;
        nav_Agent.SetDestination(_point);
    }

    public void OnStopMove()
    {
        ChangeAnim("Idle");
        nav_Agent.velocity = Vector3.zero;
        nav_Agent.isStopped = true;
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

    public void ChangeState(IState_Zombie _newState)
    {
        if (currentState != null)
            currentState.OnExit(this);

        currentState = _newState;

        if (currentState != null)
            currentState.OnEnter(this);
    }

    #region Get -

    public float GetRadiusAttack() => attackRadius;

    #endregion
}