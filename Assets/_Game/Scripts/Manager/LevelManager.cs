using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Level")]
    [SerializeField] Data_Level[] data_LevelAlls;
    int levelIndex;
    public Data_Level[] GetArrayDataLevel() => data_LevelAlls;
    [SerializeField] Data_Level data_Level;
    public Data_Level GetLevel => data_Level;

    [Header("Homtown")]
    [SerializeField] Barrier barrier;
    [SerializeField] Bus bus;
    public Bus GetBus => bus;

    [Header("Spawn Homtown")]
    [SerializeField] Transform posSpawn_Barrier;
    [SerializeField] Transform posSpawn_Bus;

    [Header("Spawn Zombie")]
    [SerializeField] SpawnZombieManager spawnZombieManager;

    [Header("List Spawn Hero")]
    [SerializeField] Transform posSpawn_Hero;
    [SerializeField] List<Hero> heros = new List<Hero>();


    void Start()
    {
        //fix setting cho len ben tren tat ca UI
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
        UIManager.Instance.OpenUI<Canvas_SelectLevel>();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
        OnInit();
    }

    public void OnInit()
    {
        //khoi tao cac thong so truoc khi bat dau man choi
        SpawnHomtown_BarrierAndBus();
    }

    private void Update()
    {

    }

    public void OnPlay()
    {
        //bat dau man choi

    }

    public void LoadLevel(int level)
    {
        levelIndex = level;
        data_Level = data_LevelAlls[levelIndex];
        LoadData_Homtown(data_Level);
        spawnZombieManager.OnInit();//load time spawn zombie
        //load lai object trong man choi
    }

    public void OnWin()
    {
        //thang
        data_LevelAlls[levelIndex + 1].SetUnlockLevel(true);
        data_Level.SetPlayDone(true);

        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Win>();
    }

    public void OnLose()
    {
        //thua
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Lose>();
    }

    public void OnNextLevel()
    {
        //next 1 level
        OnDespawn();
        OnInit();
        LoadLevel(++levelIndex);
    }

    public void OnRetryLevel()
    {
        //choi lai level
        OnDespawn();
        OnInit();
        LoadLevel(levelIndex);
    }

    public void OnDespawn()
    {
        //reset tat ca cac thong so cua man choi
        spawnZombieManager.OnDespawn();
        DeleteAll_Hero();
    }

    private void DeleteAll_Hero()
    {
        for (int i = 0; i < heros.Count; i++)
        {
            Destroy(heros[i].gameObject);
        }
        heros.Clear();
    }

    public void CollectItem(AddDictionaryItem item)
    {
        //thu thap nhung thang item da hoan thanh
    }

    public void Spawn_Hero(PoolType poolType)
    {
        Hero newHero = SimplePool.Spawn<Hero>(poolType, posSpawn_Hero.position, posSpawn_Hero.rotation);
        newHero.Setbarrier(barrier);
        newHero.OnInit();
        heros.Add(newHero);
    }

    private void LoadData_Homtown(Data_Level _data_Level)
    {
        bus.OnInit(_data_Level.Get_HpBus());
        barrier.OnInit(_data_Level.Get_HpBarrier());
    }

    private void SpawnHomtown_BarrierAndBus()
    {
        if (bus != null)
        {
            //print("Bus");
            bus.gameObject.SetActive(true);
            //print("Bus Delete");
        }
        else
            bus = SimplePool.Spawn<Bus>(PoolType.Bus, posSpawn_Bus.position, posSpawn_Bus.rotation);

        if (barrier != null)
        {
            //print("barrier");
            barrier.gameObject.SetActive(true);
            //sprint("barrier Delete");
        }
        else
            barrier = SimplePool.Spawn<Barrier>(PoolType.Barrier, posSpawn_Barrier.position, posSpawn_Barrier.rotation);
    }
}
