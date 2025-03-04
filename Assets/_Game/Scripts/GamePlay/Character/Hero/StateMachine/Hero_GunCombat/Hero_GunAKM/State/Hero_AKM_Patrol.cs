using UnityEngine;

public class Hero_AKM_Patrol : IState_HeroGunCombat
{
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {

    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {
        //sua check them ham bool (hero_GunCombat.ZombieTarget == null) de khong bi truy cap lung tung
        if (hero_GunCombat.ZombieTarget_Null_True())
        {
            //hero_GunCombat.ZombieTarget.OnInit();
            //Debug.Log("Null");
            hero_GunCombat.GetSetZombie_InSeeRadius();

            if (hero_GunCombat.ZombieTarget_Null_True())
            {
                if (hero_GunCombat.SeeBarrier())
                {
                    hero_GunCombat.ChangeState(new Hero_AKM_WaitTarget());
                }
                else
                    hero_GunCombat.OnMoveToHomeTownTarget();
            }

        }

        if (!hero_GunCombat.ZombieTarget_Null_True())
        {
            //Debug.Log("!= Null");
            hero_GunCombat.CheckDirX_SetZombieTarget();
            hero_GunCombat.CheckTargetDeath();

            if (hero_GunCombat.ZombieTarget_Null_True())
            {
                hero_GunCombat.OnMoveToHomeTownTarget();
                return;
            }
            else
            {
                if (hero_GunCombat.HaveCharaterTarget_InAttackRadius())
                {

                    if (hero_GunCombat.CheckRotationToTarget_AndRotationIfFalse(hero_GunCombat.GetTranformZombieTarget(), 2f))
                    {
                        if (hero_GunCombat.HaveCharaterTarget_InAttackRadius())
                        {
                            hero_GunCombat.ChangeState(new Hero_AKM_Shoot());
                            return;
                        }
                    }
                    //hero_GunCombat.StartCoroutine(hero_GunCombat.IERotationToTarget(hero_GunCombat.ZombieTarget.transform, timer - .3f));
                    hero_GunCombat.OnStopMove();
                }
                else
                {
                    hero_GunCombat.OnMoveToCharacterTarget();
                }
            }
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.OnStopMove();
    }
}