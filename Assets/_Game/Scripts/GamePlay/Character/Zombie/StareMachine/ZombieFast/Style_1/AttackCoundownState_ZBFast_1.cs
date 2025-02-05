public class AttackCoundownState_ZBFast_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        zombie.OnStopMove();
    }

    public void OnExecute(Zombie zombie)
    {
        if (!zombie.HaveHowmTownOrCharacterInAttackCheck())
        {
            zombie.ChangeState(new PatrolState_ZBFast_1());
            return;
        }

        if (zombie.CanAttackBus)
        {

            if (zombie.CanAttackCoundown())
                zombie.ChangeState(new AttackState_ZBFast_1());
        }
        else
        {
            if (zombie.HaveCharater_InAttackRadius())
            {
                if (zombie.CanAttackCoundown())
                    zombie.ChangeState(new AttackState_ZBFast_1());
            }
            else
            {
                zombie.ChangeState(new PatrolState_ZBFast_1());
            }
        }


    }

    public void OnExit(Zombie zombie)
    {

    }
}
