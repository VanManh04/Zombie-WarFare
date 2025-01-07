using UnityEngine;

public class HeroSword_1_PatrolState : IState_Hero
{
    bool MoveAndRotationTarget;
    float timmer;
    public void OnEnter(Hero hero)
    {
        MoveAndRotationTarget = false;
    }

    public void OnExecute(Hero hero)
    {
        //Debug.Log(Vector3.Distance(hero.transform.position, hero.ZombieTarget.transform.position));

        if (hero.ZombieTarget == null)
        {
            hero.GetSetZombie_InSeeRadius();
            hero.OnMoveToPoint(hero.PaveTheWayTarget.transform.position);
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
                        hero.ChangeState(new HeroSword_1_Attack_1_State());
                    else if (randomSkill == 2)
                        hero.ChangeState(new HeroSword_1_Attack_2_State());
                    else
                        hero.ChangeState(new HeroSword_1_Attack_3_State());

                    timmer = 10;
                }
                return;
            }

            if (Vector3.Distance(hero.transform.position, hero.ZombieTarget.transform.position) <= 2)
            {
                MoveAndRotationTarget = true;
                hero.OnStopMove();
                Vector3 poinTarget = hero.ZombieTarget.transform.position - Vector3.right * 1.5f;
                poinTarget = new Vector3(poinTarget.x, hero.transform.position.y, poinTarget.z);
                hero.StartCoroutine(hero.IEMoveAndRotationToTarget(poinTarget, Quaternion.Euler(0, 90, 0), 1f));
                timmer = 1.2f;
                //Debug.Log(poinTarget);
            }
            else
                hero.OnMoveToPoint(hero.ZombieTarget.transform.position);
        }

    }

    public void OnExit(Hero hero)
    {
        hero.OnStopMove();
    }
}