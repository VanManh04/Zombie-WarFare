using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTER_X_Skill_2 : IState_Zombie
{
    float timmer;
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Attack");
        zombie.AttackSkillIndex(2);
        timmer = 1.15f;
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Attack");
        timmer -= Time.deltaTime;

        if (timmer <= 0)
            zombie.ChangeState(new MONSTER_X_CoundownAttack());
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Attack");
        zombie.ResetLastTimeAttack();
        zombie.CheckTargetDeath();
    }
}