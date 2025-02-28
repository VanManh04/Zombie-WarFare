using UnityEngine;

public class HeroSword_1_RutKiemState : IState_HeroCloseCombat
{
    float timmer;
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        timmer = 1.48f;
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        timmer -= Time.deltaTime;
        if (timmer <= 0)
            hero_CloseCombat.ChangeState(new HeroSword_1_PatrolState());
    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {

    }
}