using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGunCombat_Death_Default : IState_HeroGunCombat
{
    float timer;
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        timer = 5;
        hero_GunCombat.OnStopMove();
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            hero_GunCombat.OnDesPawn();
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {

    }
}