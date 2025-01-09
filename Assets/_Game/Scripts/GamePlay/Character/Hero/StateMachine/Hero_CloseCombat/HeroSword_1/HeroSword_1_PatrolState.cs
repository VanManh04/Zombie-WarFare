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
        //Debug.Log(Vector3.Distance(hero.transform.position, hero.ZombieTarget.transform.position));

        if (hero_CloseCombat.ZombieTarget == null)
        {
            hero_CloseCombat.GetSetZombie_InSeeRadius();
            hero_CloseCombat.OnMoveToPoint(hero_CloseCombat.PaveTheWayTarget.transform.position);
        }
        else
        {
            if (MoveAndRotationTarget == true)
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

            if (Vector3.Distance(hero_CloseCombat.transform.position, hero_CloseCombat.ZombieTarget.transform.position) <= 2)
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