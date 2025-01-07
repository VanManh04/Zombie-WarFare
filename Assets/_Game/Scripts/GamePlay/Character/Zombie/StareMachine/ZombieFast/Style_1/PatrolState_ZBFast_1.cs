public class PatrolState_ZBFast_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Patrol");
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Patrol");
        //TODO: check attack
        if (zombie.CanAttackBus)
        {
            if (zombie.CanAttackCoundown())
                zombie.ChangeState(new AttackState_ZBFast_1());
            else
                zombie.ChangeState(new AttackCoundownState_ZBFast_1());
        }
        else
        {
            zombie.CheckAndSetCanAttackBus();

            if (zombie.HeroTarget == null)
            {
                zombie.GetSetHero_InSeeRadius();

                zombie.OnMoveToPoint(zombie.BusTarget.transform.position);
            }
            else
            {
                zombie.OnMoveToPoint(zombie.HeroTarget.transform.position);

                zombie.CheckDirX_SetHeroTarget();

                if (zombie.HaveCharater_InAttackRadius())
                {
                    if (zombie.CanAttackCoundown())
                        zombie.ChangeState(new AttackState_ZBFast_1());
                    else
                        zombie.ChangeState(new AttackCoundownState_ZBFast_1());
                }
            }
        }
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Patrol");
        zombie.OnStopMove();
    }
}
