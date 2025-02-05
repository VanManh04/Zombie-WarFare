using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Creep1_Attack_1 : IState_Zombie
{
    float timer;
    public void OnEnter(Zombie zombie)
    {
        zombie.AttackSkillIndex(1);
        timer = 1.05f;
    }

    public void OnExecute(Zombie zombie)
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            zombie.ChangeState(new Zombie_Creep1_Patrol());
        }
    }

    public void OnExit(Zombie zombie)
    {
        zombie.ResetLastTimeAttack();
        zombie.OnStopMove();
    }
}