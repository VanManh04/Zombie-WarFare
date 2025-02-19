using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTER_X_Patrol : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Patrol");
        zombie.OnMoveToHomeTownTarget();
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Patrol");
        if (zombie.CanAttackBus)
        {
            if (zombie.HaveHowmTownOrCharacterInAttackCheck())
            {
                if (zombie.CanAttackCoundown())
                {
                    if (Random.Range(0, 50) < 25)
                    zombie.ChangeState(new MONSTER_X_Skill_1());
                    else
                    zombie.ChangeState(new MONSTER_X_Skill_2());
                }
                else
                    zombie.ChangeState(new MONSTER_X_CoundownAttack());
            }
            else
                zombie.ChangeState(new Zombie_Idle_Default());
        }
        else
        {
            zombie.CheckAndSetCanAttackBus();
            zombie.GetSetHero_InSeeRadius();
            if (!zombie.HeroTarget_Null_True())
            {
                zombie.OnMoveToCharacterTarget();
                zombie.CheckDirX_SetHeroTarget();
                zombie.CheckTargetDeath();
                if (zombie.HaveCharater_InAttackRadius())
                {
                    if (zombie.CanAttackCoundown())
                        zombie.ChangeState(new MONSTER_X_Skill_1());
                    else
                        zombie.ChangeState(new MONSTER_X_CoundownAttack());
                }
            }
            else
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