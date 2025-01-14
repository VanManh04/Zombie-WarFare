using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_AKM_Reload : IState_HeroGunCombat
{
    float timer;
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.Reload();
        timer = 3.3f;
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {
        timer -= Time.deltaTime;
        hero_GunCombat.CheckDirX_SetZombieTarget();
        hero_GunCombat.CheckTargetDeath();
        if (timer <= 0)
        {
            if (hero_GunCombat.ZombieTarget != null && hero_GunCombat.HaveCharaterTarget_InAttackRadius())
            {
                hero_GunCombat.ChangeState(new Hero_AKM_Shoot());
            }else
            {
                hero_GunCombat.ChangeState(new Hero_AKM_Patrol());
            }
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    { 

    }
}