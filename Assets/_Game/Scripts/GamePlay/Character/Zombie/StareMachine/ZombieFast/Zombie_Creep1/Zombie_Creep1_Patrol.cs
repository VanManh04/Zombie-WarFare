using UnityEngine;

public class Zombie_Creep1_Patrol : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        if (!zombie.HaveCharater_InAttackRadius())
            zombie.OnMoveToPoint(zombie.BusTarget.transform.position);
    }

    public void OnExecute(Zombie zombie)
    {
        if (zombie.CanAttackBus)
        {
            if (zombie.HaveHowmTownOrCharacterInAttackCheck())
            {
                if (zombie.CanAttackCoundown())
                {
                    if (Random.Range(0, 100) < 50)
                        zombie.ChangeState(new Zombie_Creep1_Attack_1());
                    else
                        zombie.ChangeState(new Zombie_Creep1_Attack_2());
                }

            }
            else
                zombie.ChangeState(new Zombie_Creep1_Idle());
        }
        else
        {
            zombie.CheckAndSetCanAttackBus();

            if (zombie.HaveCharater_InAttackRadius())
            {
                zombie.OnStopMove();
                if (zombie.CanAttackCoundown())
                {
                    if (Random.Range(0, 100) < 50)
                        zombie.ChangeState(new Zombie_Creep1_Attack_1());
                    else
                        zombie.ChangeState(new Zombie_Creep1_Attack_2());
                }
                else
                    zombie.ChangeState(new Zombie_Creep1_AttackCoundown());
            }
            else
            {
                zombie.OnMoveToPoint(zombie.BusTarget.transform.position);
            }
        }
    }

    public void OnExit(Zombie zombie)
    {
        zombie.OnStopMove();
    }
}