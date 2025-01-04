using System.Collections;
using UnityEngine;

public class IdleState_ZBFast_1 : IState_Zombie
{
    float randomTime;
    float timmer;
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Idle");
        timmer = 0;

        if (randomTime < 0)
            return;
        randomTime = zombie.GetIdleTime();
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Idle");
        timmer += Time.deltaTime;
        if(timmer >= randomTime)
            zombie.ChangeState(new PatrolState_ZBFast_1());
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Idle");
        randomTime = -1;
    }
}