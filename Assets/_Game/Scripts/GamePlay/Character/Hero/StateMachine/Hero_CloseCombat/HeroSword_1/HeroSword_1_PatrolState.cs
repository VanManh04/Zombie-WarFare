using UnityEngine;

public class HeroSword_1_PatrolState : IState_HeroCloseCombat
{
    bool MoveAndRotationTarget;
    float timmer;
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        MoveAndRotationTarget = false;
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        if (hero_CloseCombat.CanAttackBarrier)
        {
            if (hero_CloseCombat.HaveHowmTownOrCharacterInAttackCheck())
            {
                int randomSkill = Random.Range(1, 4);

                if (randomSkill == 1)
                    hero_CloseCombat.ChangeState(new HeroSword_1_Attack_1_State());
                else if (randomSkill == 2)
                    hero_CloseCombat.ChangeState(new HeroSword_1_Attack_2_State());
                else
                    hero_CloseCombat.ChangeState(new HeroSword_1_Attack_3_State());
            }
            else
            {
                hero_CloseCombat.ChangeState(new HeroSword_1_IdleState());
            }
            return;
        }


        if (hero_CloseCombat.ZombieTarget == null)
        {
            hero_CloseCombat.GetSetZombie_InSeeRadius();
            hero_CloseCombat.OnMoveToHomeTownTarget();
            hero_CloseCombat.CheckCanAttackBarrier();
        }
        else
        {
            hero_CloseCombat.CheckDirX_SetZombieTarget();
            if (hero_CloseCombat.ZombieTarget == null)
                return;
            if (MoveAndRotationTarget)
            {
                timmer -= Time.deltaTime;
                if (timmer <= 0)
                {
                    int randomSkill = Random.Range(1, 4);

                    if (randomSkill == 1)
                        hero_CloseCombat.ChangeState(new HeroSword_1_Attack_1_State());
                    else if (randomSkill == 2)
                        hero_CloseCombat.ChangeState(new HeroSword_1_Attack_2_State());
                    else
                        hero_CloseCombat.ChangeState(new HeroSword_1_Attack_3_State());

                    timmer = 10;
                }
                return;
            }

            if (Vector3.Distance(hero_CloseCombat.transform.position, hero_CloseCombat.ZombieTarget.transform.position) <= 1)
            {
                MoveAndRotationTarget = true;
                hero_CloseCombat.OnStopMove();
                Vector3 poinTarget = hero_CloseCombat.ZombieTarget.transform.position - Vector3.right * 1.5f;
                poinTarget = new Vector3(poinTarget.x, hero_CloseCombat.transform.position.y, poinTarget.z);
                hero_CloseCombat.StartCoroutine(hero_CloseCombat.IEMoveAndRotationToTarget(poinTarget, Quaternion.Euler(0, 90, 0), 1f));
                timmer = 1.2f;
                //Debug.Log(poinTarget);
            }
            else
                hero_CloseCombat.OnMoveToPoint(hero_CloseCombat.ZombieTarget.transform.position);
        }

    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.OnStopMove();
    }
}