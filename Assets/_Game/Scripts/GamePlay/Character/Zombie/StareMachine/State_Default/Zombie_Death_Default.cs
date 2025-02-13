using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Death_Default : IState_Zombie
{
    float timer;
    public void OnEnter(Zombie zombie)
    {
        timer = 5;
        zombie.OnStopMove();
    }

    public void OnExecute(Zombie zombie)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            zombie.OnDesPawn();
        }
    }

    public void OnExit(Zombie zombie)
    {

    }
}