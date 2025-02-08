using UnityEngine;

public class HeroCloseCombat_Death_Default : IState_HeroCloseCombat
{
    float timer;
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        timer = 5;
        hero_CloseCombat.OnStopMove();
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            hero_CloseCombat.OnDesPawn();
        }
    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {

    }
}