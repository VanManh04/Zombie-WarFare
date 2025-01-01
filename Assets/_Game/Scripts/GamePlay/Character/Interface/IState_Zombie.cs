public interface IState_Zombie
{
    void OnEnter(Zombie zombie);
    void OnExecute(Zombie zombie);
    void OnExit(Zombie zombie);
}