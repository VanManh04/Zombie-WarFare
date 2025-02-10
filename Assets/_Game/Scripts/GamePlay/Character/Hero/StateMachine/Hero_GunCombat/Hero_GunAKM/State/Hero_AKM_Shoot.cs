using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_AKM_Shoot : IState_HeroGunCombat
{
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.Attack();
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.RotationToTarget(hero_GunCombat.ZombieTarget.transform);
        if (hero_GunCombat.OutOfAmmo())
        {
            hero_GunCombat.ChangeState(new Hero_AKM_Reload());
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {
        //TODO Stop Anim Shoot
        Debug.LogError("Done Shoot");
    }
}