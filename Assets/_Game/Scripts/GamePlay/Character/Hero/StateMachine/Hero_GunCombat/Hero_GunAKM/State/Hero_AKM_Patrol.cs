using UnityEngine;

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
            hero_GunCombat.OnMoveToPoint(hero_GunCombat.ThisBarrier.transform.position);

            hero_GunCombat.GetSetZombie_InSeeRadius();
            if (hero_GunCombat.SeeBarrier())
            {
                hero_GunCombat.ChangeState(new Hero_AKM_WaitTarget());
            }
        }
        else
        {
            hero_GunCombat.CheckDirX_SetZombieTarget();
            hero_GunCombat.CheckTargetDeath();

            if (hero_GunCombat.ZombieTarget == null)
            {
                hero_GunCombat.OnStopMove();
                return;
            }

            //TODO: MoveTopint + move to rotation
            if (ReadyMoveForwatAndAttack)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    if (hero_GunCombat.HaveCharaterTarget_InAttackRadius())
                        hero_GunCombat.ChangeState(new Hero_AKM_Shoot());
                    else
                        ReadyMoveForwatAndAttack = false;
                }
            }
            else
            {
                hero_GunCombat.OnMoveToPoint(hero_GunCombat.ZombieTarget.transform.position);
                //Debug.Log("Move");

                if (hero_GunCombat.HaveCharaterTarget_InAttackRadius())
                {
                    //Debug.Log("IE");
                    ReadyMoveForwatAndAttack = true;
                    hero_GunCombat.StartCoroutine(hero_GunCombat.IERotationToTarget(hero_GunCombat.ZombieTarget.transform, timer - .3f));
                }
            }
        }
    }

    public void OnExit(Hero_GunCombat hero_GunCombat)
    {
        hero_GunCombat.OnStopMove();
    }
}