using Unity.AI.Navigation;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameState gameState;

    [Header("Manager")]
    [SerializeField] LevelManager levelManager;
    [SerializeField] SpawnZombieManager spawnZombieManager;
    [SerializeField] NavMeshSurface meshSurface;

    void Start()
    {

    }

    void Update()
    {
        SetPauseGame();
    }

    private void SetPauseGame()
    {
        if (gameState == GameState.GamePlay)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

    public void ChangeGameState(GameState _gameState) => gameState = _gameState;
    public GameState GetGameState() => gameState;
}
