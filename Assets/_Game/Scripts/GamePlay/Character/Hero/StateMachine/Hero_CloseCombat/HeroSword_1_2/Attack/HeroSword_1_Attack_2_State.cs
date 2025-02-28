using UnityEngine;

public class HeroSword_1_Attack_2_State : IState_HeroCloseCombat
{
    float timmer;
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.AttackSkillIndex(2);//change anim
        timmer = 1.199f;
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