using UnityEngine;

public class HeroSword_1_Attack_3_State : IState_Hero
{
    float timmer;
    public void OnEnter(Hero hero)
    { 
        hero.AttackSkillIndex(3);
        timmer = 1.731f;
    }

    public void OnExecute(Hero hero)
    {
        timmer -= Time.deltaTime;

        if (timmer <= 0)
            hero.ChangeState(new HeroSword_1_AttackCountdownState());
    }

    public void OnExit(Hero hero)
    {
        hero.ResetLastTimeAttack();
        hero.CheckTargetDeath();
    }
}