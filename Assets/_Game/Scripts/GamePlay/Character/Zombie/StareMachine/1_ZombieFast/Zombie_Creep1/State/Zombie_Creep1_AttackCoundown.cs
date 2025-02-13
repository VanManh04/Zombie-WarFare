using UnityEngine;

public class Zombie_Creep1_AttackCoundown : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        zombie.OnStopMove();
    }

    public void OnExecute(Zombie zombie)
    {
        if (zombie.HaveCharater_InAttackRadius())
        {
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
            zombie.ChangeState(new Zombie_Creep1_Patrol());
        }

    }

    public void OnExit(Zombie zombie)
    {

    }
}