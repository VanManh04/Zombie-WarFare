using UnityEngine;

public class CyberMonsters2_patrol : IState_Zombie
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
                    zombie.ChangeState(new CyberMonsters2_AttackSword());
                }
                else
                    zombie.ChangeState(new CyberMonsters2_AttackCoundown());
            }
            else
                zombie.ChangeState(new Zombie_Idle_Default());
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
                        zombie.ChangeState(new CyberMonsters2_AttackSword());
                    else
                        zombie.ChangeState(new CyberMonsters2_AttackCoundown());
                }
                //else if (zombie is Cyber_Monsters_2)
                //{
                //    if (zombie.GetComponent<Cyber_Monsters_2>().CanAttackGun())
                //    {
                //        zombie.ChangeState(new CyberMonsters2_AttackGun());
                //    }
                //}
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