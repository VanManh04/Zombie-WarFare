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
                else
                    zombie.ChangeState(new Zombie_Creep1_AttackCoundown());
            }
            else
                zombie.ChangeState(new IdleState_ZBFast_1());
        }
        else
        {
            zombie.CheckAndSetCanAttackBus();
            zombie.GetSetHero_InSeeRadius();

            if (zombie.HeroTarget != null)
            {
                zombie.CheckDirX_SetHeroTarget();
                zombie.OnMoveToCharacterTarget();
                zombie.CheckTargetDeath();
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
            }
            else
            {
                zombie.OnMoveToHomeTownTarget();
            }
        }

    }

    public void OnExit(Zombie zombie)
    {
        zombie.OnStopMove();
    }
}