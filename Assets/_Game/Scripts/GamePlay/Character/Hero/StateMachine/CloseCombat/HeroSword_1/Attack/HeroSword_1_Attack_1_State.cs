using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSword_1_Attack_1_State : IState_Hero
{
    float timmer;
    public void OnEnter(Hero hero)
    {
        hero.AttackSkillIndex(1);//change anim + dodamage
        timmer = 1.496f;
    }

    public void OnExecute(Hero hero)
    {
        timmer -= Time.deltaTime;

        if(timmer <= 0)
            hero.ChangeState(new HeroSword_1_AttackCountdownState());
    }

    public void OnExit(Hero hero)
    {
        hero.ResetLastTimeAttack();
        hero.CheckTargetDeath();
    }
}