using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberMonsters2_AttackSword : IState_Zombie
{
    float timmer;
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Attack");
        zombie.AttackSkillIndex(1);
        timmer = 1.12f;
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Attack");
        timmer -= Time.deltaTime;

        if (timmer <= 0)
            zombie.ChangeState(new CyberMonsters2_AttackCoundown());
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Attack");
        zombie.ResetLastTimeAttack();
        zombie.CheckTargetDeath();
    }
}