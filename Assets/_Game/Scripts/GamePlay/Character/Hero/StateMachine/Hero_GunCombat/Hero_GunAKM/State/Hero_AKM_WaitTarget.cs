using UnityEngine;


public class Hero_AKM_WaitTarget : IState_HeroGunCombat
{
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.WaitTarget_anim();
        hero_GunCombat.OnStopMove();
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.GetSetZombie_InSeeRadius();
        if (hero_GunCombat.ZombieTarget != null)
        {
            hero_GunCombat.ChangeState(new Hero_AKM_Patrol());
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {
        
    }
}