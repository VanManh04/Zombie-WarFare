using UnityEngine;

public class HeroSword_1_RutKiemState : IState_Hero
{
    float timmer;
    public void OnEnter(Hero hero)
    {
        timmer = 1.48f;
    }

    public void OnExecute(Hero hero)
    {
        timmer -= Time.deltaTime;
        if (timmer <= 0)
            hero.ChangeState(new HeroSword_1_IdleState());
    }

    public void OnExit(Hero hero)
    {

    }
}