using UnityEngine;

public class MONSTER_X_CoundownAttack : IState_Zombie
{
    public void OnEnter(Zombie zombie)
    {
        zombie.AttackCoundown();
    }

    public void OnExecute(Zombie zombie)
    {
        if (!zombie.HaveHowmTownOrCharacterInAttackCheck())
        {
            zombie.ChangeState(new MONSTER_X_Patrol());
            return;
        }

        if (zombie.CanAttackBus)
        {

            if (zombie.CanAttackCoundown())
            {
                if (Random.Range(0, 50) < 25)
                    zombie.ChangeState(new MONSTER_X_Skill_1());
                else
                    zombie.ChangeState(new MONSTER_X_Skill_2());
            }
            else
                zombie.ChangeState(new MONSTER_X_CoundownAttack());
        }
        else
        {
            if (zombie.HaveCharater_InAttackRadius())
            {
                if (zombie.CanAttackCoundown())
                {
                    if (Random.Range(0, 50) < 25)
                        zombie.ChangeState(new MONSTER_X_Skill_1());
                    else
                        zombie.ChangeState(new MONSTER_X_Skill_2());
                }
                else
                    zombie.ChangeState(new MONSTER_X_CoundownAttack());
            }
            else
            {
                zombie.ChangeState(new MONSTER_X_Patrol());
            }
        }
    }

    public void OnExit(Zombie zombie)
    {

    }
}