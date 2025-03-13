using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberMonsters2_AttackCoundown : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        zombie.AttackCoundown();
    }

    public void OnExecute(Zombie zombie)
    {
        if (!zombie.HaveHowmTownOrCharacterInAttackCheck())
        {
            zombie.ChangeState(new CyberMonsters2_patrol());
            return;
        }

        if (zombie.CanAttackBus)
        {

            if (zombie.CanAttackCoundown())
            {
                    zombie.ChangeState(new CyberMonsters2_AttackSword());
            }
            else
                zombie.ChangeState(new CyberMonsters2_AttackCoundown());
        }
        else
        {
            if (zombie.HaveCharater_InAttackRadius())
            {
                if (zombie.CanAttackCoundown())
                {
                    zombie.ChangeState(new CyberMonsters2_AttackSword());
                }
                else
                    zombie.ChangeState(new CyberMonsters2_AttackCoundown());
            }
            else
            {
                zombie.ChangeState(new CyberMonsters2_patrol());
            }
        }
    }

    public void OnExit(Zombie zombie)
    {

    }
}