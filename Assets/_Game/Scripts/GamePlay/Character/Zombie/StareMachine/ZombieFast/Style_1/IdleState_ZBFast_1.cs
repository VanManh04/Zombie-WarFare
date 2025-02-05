using System.Collections;
using UnityEngine;

public class IdleState_ZBFast_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Idle");
        zombie.OnStopMove();
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Idle");
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Idle");
    }
}