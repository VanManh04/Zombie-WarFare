using System.Collections;
using UnityEngine;
public class AttackState_ZBNormal_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Attack");
        
        zombie.Attack();
    }

    public void OnExecute(Zombie zombie)
    {
       //Debug.Log("Execute: Attack");
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Attack");
    }
}
