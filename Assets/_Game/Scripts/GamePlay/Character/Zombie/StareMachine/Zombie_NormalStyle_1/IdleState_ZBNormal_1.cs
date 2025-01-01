using System.Collections;
using UnityEngine;

public class IdleState_ZBNormal_1 : IState_Zombie
{
    float randomTime;
    float timmer;
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Idle");
        timmer = 0;

        if (randomTime < 0)
            return;
        randomTime = Random.Range(0, 5);
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Idle");
        timmer += Time.deltaTime;
        if(timmer >= randomTime)
            zombie.ChangeState(new PatrolState_ZBNormal_1());
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Idle");
        randomTime = -1;
    }
}