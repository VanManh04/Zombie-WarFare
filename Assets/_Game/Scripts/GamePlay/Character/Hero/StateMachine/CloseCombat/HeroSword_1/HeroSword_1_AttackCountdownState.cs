using UnityEngine;

public class HeroSword_1_AttackCountdownState : IState_Hero
{
    public void OnEnter(Hero hero)
    {
        hero.OnStopMove();
        //Vector3 poinTarget = hero.ZombieTarget.transform.position - Vector3.right * 1.5f;
        //poinTarget = new Vector3(poinTarget.x, hero.transform.position.y, poinTarget.z);
        //hero.StartCoroutine(hero.IEMoveAndRotationToTarget(poinTarget, Quaternion.Euler(0, 90, 0), .5f));
    }

    public void OnExecute(Hero hero)
    {
        if (hero.HaveCharater_InAttackRadius())
        {
            if (hero.CanAttackCoundown())
            {
                int randomSkill = Random.Range(1, 4);

                if (randomSkill == 1)
                    hero.ChangeState(new HeroSword_1_Attack_1_State());
                else if (randomSkill == 2)
                    hero.ChangeState(new HeroSword_1_Attack_2_State());
                else
                    hero.ChangeState(new HeroSword_1_Attack_3_State());
            }

        }
        else
            hero.ChangeState(new HeroSword_1_PatrolState());
    }

    public void OnExit(Hero hero)
    {

    }
}