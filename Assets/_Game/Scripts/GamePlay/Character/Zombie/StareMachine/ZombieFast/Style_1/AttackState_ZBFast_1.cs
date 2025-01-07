using UnityEngine;

public class AttackState_ZBFast_1 : IState_Zombie
{
    float timmer;
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Attack");
        zombie.Attack();
        timmer = 0.8329161f;
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Attack");
        timmer -= Time.deltaTime;

        if (timmer <= 0)
            zombie.ChangeState(new AttackCoundownState_ZBFast_1());
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Attack");
        zombie.ResetLastTimeAttack();
        zombie.CheckTargetDeath();
    }
}
