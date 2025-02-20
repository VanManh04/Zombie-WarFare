public class PatrolState_ZBFast_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Patrol");
        zombie.OnMoveToPoint(zombie.BusTarget.transform.position);
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Patrol");
        if (zombie.CanAttackBus)
        {
            if (zombie.HaveHowmTownOrCharacterInAttackCheck())
            {
                if (zombie.CanAttackCoundown())
                    zombie.ChangeState(new AttackState_ZBFast_1());
                else
                    zombie.ChangeState(new AttackCoundownState_ZBFast_1());
            }
            else
                zombie.ChangeState(new IdleState_ZBFast_1());
        }
        else
        {
            zombie.CheckAndSetCanAttackBus();
            zombie.GetSetHero_InSeeRadius();
            if (!zombie.HeroTarget_Null_True() && zombie.CanTargetHero())
            {
                zombie.OnMoveToCharacterTarget();
                zombie.CheckDirX_SetHeroTarget();
                zombie.CheckTargetDeath();
                if (zombie.HaveCharater_InAttackRadius())
                {
                    if (zombie.CanAttackCoundown())
                    {
                        zombie.ChangeState(new AttackState_ZBFast_1());
                    }
                    else
                    {
                        zombie.ChangeState(new AttackCoundownState_ZBFast_1());
                    }
                }
            }else
            {
                zombie.OnMoveToHomeTownTarget();
            }
        }
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Patrol");
        zombie.OnStopMove();
    }
}
