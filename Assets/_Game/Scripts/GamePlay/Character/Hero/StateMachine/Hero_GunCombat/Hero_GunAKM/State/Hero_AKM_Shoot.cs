public class Hero_AKM_Shoot : IState_HeroGunCombat
{
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.Attack();
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {

        hero_GunCombat.RotationToTarget(hero_GunCombat.GetTranformZombieTarget());
        if (hero_GunCombat.OutOfAmmo())
        {
            hero_GunCombat.CheckTargetDeath();
            if (hero_GunCombat.ZombieTarget_Null_True())
            {
                hero_GunCombat.ChangeState(new Hero_AKM_Reload());
            }
            else
                hero_GunCombat.ChangeState(new Hero_AKM_Reload());
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {

    }
}