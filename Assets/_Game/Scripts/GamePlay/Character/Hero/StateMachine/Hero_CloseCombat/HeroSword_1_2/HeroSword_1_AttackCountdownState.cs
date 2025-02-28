using UnityEngine;

public class HeroSword_1_AttackCountdownState : IState_HeroCloseCombat
{
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.OnStopMove();
        //Vector3 poinTarget = hero.ZombieTarget.transform.position - Vector3.right * 1.5f;
        //poinTarget = new Vector3(poinTarget.x, hero.transform.position.y, poinTarget.z);
        //hero.StartCoroutine(hero.IEMoveAndRotationToTarget(poinTarget, Quaternion.Euler(0, 90, 0), .5f));
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        if (hero_CloseCombat.HaveCharater_InAttackRadius())
        {
            if (hero_CloseCombat.CanAttackCoundown())
            {
                if (hero_CloseCombat.poolType == PoolType.HeroSword_1)
                {
                    int randomSkill = Random.Range(1, 3);

                    if (randomSkill == 1)
                        hero_CloseCombat.ChangeState(new HeroSword_1_2_Attack_1_State());
                    else
                        hero_CloseCombat.ChangeState(new HeroSword_1_Attack_2_State());
                }
                else
                {
                    int randomSkill = Random.Range(1, 4);

                    if (randomSkill == 1)
                        hero_CloseCombat.ChangeState(new HeroSword_1_2_Attack_1_State());
                    else if (randomSkill == 2)
                        hero_CloseCombat.ChangeState(new HeroSword_2_Attack_2_State());
                    else
                        hero_CloseCombat.ChangeState(new HeroSword_2_Attack_3_State());
                }
            }

        }
        else
            hero_CloseCombat.ChangeState(new HeroSword_1_PatrolState());
    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {

    }
}