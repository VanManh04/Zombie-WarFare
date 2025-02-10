public class Hero_AKM_Patrol : IState_HeroGunCombat
{
    bool ReadyMoveForwatAndAttack;
    float timer;
    public void OnEnter(Hero_GunCombat hero_GunCombat)
    {
        ReadyMoveForwatAndAttack = false;
        timer = .8f;
    }

    public void OnExecute(Hero_GunCombat hero_GunCombat)
    {

        if (hero_GunCombat.ZombieTarget == null)
        {

            hero_GunCombat.GetSetZombie_InSeeRadius();

            if (hero_GunCombat.ZombieTarget == null)
            {
                if (hero_GunCombat.SeeBarrier())
                {
                    hero_GunCombat.ChangeState(new Hero_AKM_WaitTarget());
                }
                else
                    hero_GunCombat.OnMoveToHomeTownTarget();
            }

        }

        if (hero_GunCombat.ZombieTarget != null)
        {
            hero_GunCombat.CheckDirX_SetZombieTarget();
            hero_GunCombat.CheckTargetDeath();

            if (hero_GunCombat.ZombieTarget == null)
            {
                hero_GunCombat.OnMoveToHomeTownTarget();
                return;
            }
            else
            {
                //TODO: MoveTopint + move to rotation

                if (hero_GunCombat.HaveCharaterTarget_InAttackRadius())
                {

                    if (hero_GunCombat.CheckRotationToTarget_AndRotationIfFalse(hero_GunCombat.ZombieTarget.transform, 2f))
                    {
                        if (hero_GunCombat.HaveCharaterTarget_InAttackRadius())
                            hero_GunCombat.ChangeState(new Hero_AKM_Shoot());
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