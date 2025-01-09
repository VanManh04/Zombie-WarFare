public class HeroSword_1_IdleState : IState_HeroCloseCombat
{
    public void OnEnter(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.OnStopMove();
    }

    public void OnExecute(Hero_CloseCombat hero_CloseCombat)
    {
        hero_CloseCombat.ChangeState(new HeroSword_1_PatrolState());
    }

    public void OnExit(Hero_CloseCombat hero_CloseCombat)
    {

    }
}