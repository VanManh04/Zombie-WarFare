using UnityEngine;

public class HeroSword_2_Attack_3_State : IState_HeroCloseCombat
{
    float timmer;
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.AttackSkillIndex(3);//change anim
        timmer = 1.02f;
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        timmer -= Time.deltaTime;

        if (timmer <= 0)
            hero_CloseCombat.ChangeState(new HeroSword_1_AttackCountdownState());
    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.ResetLastTimeAttack();
        hero_CloseCombat.CheckTargetDeath();
    }
}