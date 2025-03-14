﻿using UnityEngine;

public class Hero : Character
{
    [Header("See Info")]
    [SerializeField] protected Transform seeCheck;
    [SerializeField] protected float seeRadius;

    [Header("Barrier")]
    [SerializeField] protected LayerMask whatIsBarrier;
    [SerializeField] protected Barrier thisBarrier;
    [SerializeField] protected bool canAttackBarrier;
    public bool CanAttackBarrier => canAttackBarrier;
    public Barrier ThisBarrier => thisBarrier;

    [Header("Target")]
    [SerializeField] protected Zombie zombieTarget;
    public Zombie ZombieTarget => zombieTarget;

    [Header("Coin Shopping")]
    [SerializeField] int coinShopping;

    public int GetCoinShopping => coinShopping;

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
        Gizmos.color = Color.green;
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

        if (zombieTarget != null)
            if (zombieTarget.IsDeath)
                zombieTarget = null;
    }

    public override void AttackSkillIndex(int _skillIndex)
    {
        base.AttackSkillIndex(_skillIndex);
    }

    public virtual void CheckAndSetCanAttackBus()
    {

    }

    public virtual void CheckDirX_SetZombieTarget()
    {
        if (zombieTarget != null && zombieTarget.transform.position.x < TF.position.x)
            zombieTarget = null;
    }

    //get tat ca charactor trong attack
    public virtual void GetSetZombie_InSeeRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTarget);

        if (hitColliders.Length > 0)
        {
            Zombie findTarget = null;
            float minDistance = float.MaxValue;
            foreach (var hit in hitColliders)
            {
                Zombie zombie = Cache.GenCollectZombie(hit);
                if (zombie == null || zombie.TF.position.x <= TF.position.x)
                    continue;

                float distance = Vector3.Distance(TF.position, zombie.TF.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    findTarget = zombie;
                }
            }

            zombieTarget = findTarget;
        }
        else
        {
            zombieTarget = null;
        }
    }

    public override bool HaveCharater_InAttackRadius()
    {
        return base.HaveCharater_InAttackRadius();
    }

    public override bool HaveHowmTownOrCharacterInAttackCheck()
    {
        bool haveCharacter = HaveCharater_InAttackRadius();
        bool haveBarrier;

        Collider[] hitColliders = Physics.OverlapSphere(attackCheck.position, attackRadius, whatIsBarrier);
        if (hitColliders.Length > 0)
            haveBarrier = true;
        else
            haveBarrier = false;

        return haveCharacter || haveBarrier;
    }


    public override bool HaveCharaterTarget_InAttackRadius()
    {

        if (Vector3.Distance(attackCheck.transform.position, zombieTarget.transform.position) < attackRadius)
            return true;
        else
            return false;
    }

    public virtual void DoDamageZombie()
    {

    }

    public override void DoDamage_HomeTownTarget()
    {
        base.DoDamage_HomeTownTarget();
        if (thisBarrier != null && thisBarrier.gameObject.activeSelf)
            thisBarrier.OnHit(damage);
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

    public override void OnMoveToCharacterTarget()
    {
        base.OnMoveToCharacterTarget();
        ChangeAnim(Constants.ANIM_MOVE);

        Vector3 _point = zombieTarget.transform.position;

        SetDestination_Nav(_point);
    }

    public override void OnStopMove()
    {
        base.OnStopMove();
    }

    public override void OnMoveToHomeTownTarget()
    {
        base.OnMoveToHomeTownTarget();

        ChangeAnim(Constants.ANIM_MOVE);
        nav_Agent.isStopped = false;

        Vector3 _point = TF.position;
        _point.x = thisBarrier.transform.position.x;

        SetDestination_Nav(_point);
    }
    #endregion

    public override void OnInit()
    {
        thisBarrier = LevelManager.Instance.GetBarrier;
        if (thisBarrier == null)
            OnDesPawn();

        base.OnInit();
    }

    public override void OnDesPawn()
    {
        base.OnDesPawn();
    }

    public bool SeeBarrier()
    {
        //Collider[] hitColliders = Physics.OverlapSphere(seeCheck.position, seeRadius, whatIsTheWay);

        //if (hitColliders.Length > 0)
        if (thisBarrier == null)
            return false;

        Vector3 pointBarrier = seeCheck.position;
        pointBarrier.x = ThisBarrier.transform.position.x;

        if (Vector3.Distance(seeCheck.transform.position, pointBarrier) < seeRadius)
            return true;
        return false;


    }

    public void CheckCanAttackBarrier()
    {
        Vector3 pointBarrier = attackCheck.position;
        pointBarrier.x = ThisBarrier.transform.position.x;

        if (Vector3.Distance(attackCheck.position, pointBarrier) < attackRadius)
        {
            canAttackBarrier = true;
        }
    }

    public bool ZombieTarget_Null_True()
    {
        return zombieTarget == null;
    }

    public Transform GetTranformZombieTarget()
    {
        return zombieTarget.transform;
    }
}