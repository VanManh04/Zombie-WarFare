using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Creep1_Idle : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        zombie.OnStopMove();
    }

    public void OnExecute(Zombie zombie)
    {
       
    }

    public void OnExit(Zombie zombie)
    {

    }
}