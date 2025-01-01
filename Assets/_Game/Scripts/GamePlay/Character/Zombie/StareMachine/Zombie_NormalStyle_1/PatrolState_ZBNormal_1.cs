using UnityEngine;
public class PatrolState_ZBNormal_1 : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        //Debug.Log("Enter: Patrol");
        if (zombie.Target != null)
            zombie.OnMoveToPoint(zombie.Target.transform.position);
    }

    public void OnExecute(Zombie zombie)
    {
        //Debug.Log("Execute: Patrol");
        //TODO: check attack

        Debug.Log(zombie.DistanceAttackToTarget() + " : " + zombie.GetRadiusAttack() * 1.8f);
        if (zombie.DistanceAttackToTarget() < zombie.GetRadiusAttack() * 1.8f)
            zombie.ChangeState(new AttackState_ZBNormal_1());
    }

    public void OnExit(Zombie zombie)
    {
        //Debug.Log("Exit: Patrol");
        zombie.OnStopMove();
    }
}
