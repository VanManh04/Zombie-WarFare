using System.Collections;
using UnityEngine;
public class DeathState_ZBFast_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Death");
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Death");
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Idle");
    }
}
