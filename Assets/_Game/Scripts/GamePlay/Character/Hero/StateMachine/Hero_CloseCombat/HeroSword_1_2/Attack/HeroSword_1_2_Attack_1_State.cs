using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSword_1_2_Attack_1_State : IState_HeroCloseCombat
{
    float timmer;
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.AttackSkillIndex(1);//change anim + dodamage
        timmer = 1.496f;
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        timmer -= Time.deltaTime;

        if(timmer <= 0)
            hero_CloseCombat.ChangeState(new HeroSword_1_AttackCountdownState());
    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.ResetLastTimeAttack();
        hero_CloseCombat.CheckTargetDeath();
    }
}