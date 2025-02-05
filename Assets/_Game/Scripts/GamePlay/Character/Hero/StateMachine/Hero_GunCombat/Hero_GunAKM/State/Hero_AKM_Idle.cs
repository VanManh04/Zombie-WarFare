using UnityEngine;

public class Hero_AKM_Idle : IState_HeroGunCombat
{
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.OnStopMove();
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {

    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {

    }
}