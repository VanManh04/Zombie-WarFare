public class HeroSword_1_IdleState : IState_Hero
{
    public void OnEnter(Hero hero)
    {
        hero.OnStopMove();
    }

    public void OnExecute(Hero hero)
    {
        hero.ChangeState(new HeroSword_1_PatrolState());
    }

    public void OnExit(Hero hero)
    {

    }
}