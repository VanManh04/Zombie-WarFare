using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    //TODO: Fix Set BUS BARRIER
    [Header("Level")]
    [SerializeField] Data_Level[] data_LevelAlls;
    int levelIndex;
    public Data_Level[] GetArrayDataLevel() => data_LevelAlls;
    [SerializeField] Data_Level data_Level;
    public Data_Level GetDataLevel => data_Level;

    [Header("Homtown")]
    [SerializeField] Barrier barrier;
    [SerializeField] Bus bus;
    public Bus GetBus => bus;
    public Barrier GetBarrier => barrier;

    [Header("Spawn Homtown")]
    [SerializeField] Transform posSpawn_Barrier;
    [SerializeField] Transform posSpawn_Bus;

    [Header("Spawn Zombie")]
    [SerializeField] SpawnZombieManager spawnZombieManager;

    [Header("Team Hero")]
    [SerializeField] TeamHero teamHero;
    public TeamHero TeamHero => teamHero;

    [Header("List Spawn Hero")]
    [SerializeField] Transform posSpawn_Hero;
    [SerializeField] List<Hero> heros = new List<Hero>();

    [Header("Icon Hero Info")]
    [SerializeField] Dictionary<HeroType, Sprite> iconHeros = new Dictionary<HeroType, Sprite>();

    [Header("Coin")]
    [SerializeField] int coin;


    void Start()
    {
        //fix setting cho len ben tren tat ca UI
        //UIManager.Instance.OpenUI<Canvas_GamePlay>();
        //UIManager.Instance.OpenUI<Canvas_SelectLevel>();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
        AddAlliconToDis();
        OnInit();
    }

    public void OnInit()
    {
        //khoi tao cac thong so truoc khi bat dau man choi
        coin = 10;
        SpawnHomtown_BarrierAndBus();
    }

    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.E))
        //    teamHero.AddHeroToList(HeroType.HeroSword_1);
        //if (Input.GetKeyUp(KeyCode.R))
        //    teamHero.RemoveHeroToList(HeroType.HeroSword_1);
        //if (Input.GetKeyUp(KeyCode.T))
        //    teamHero.ChangeheroList(0,HeroType.Hero_AKM);

    }

    public void OnPlay()
    {
        //bat dau man choi

    }


    public void LoadLevel(int level)
    {
        OnDespawn();

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
        //levelIndex += 1;

        OnDespawn();
        OnInit();
        LoadLevel(levelIndex++);
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
            //Destroy(heros[i].gameObject);
            heros[i].OnDesPawn();
        }
        //SimplePool.CollectAll();
        heros.Clear();
    }

    public void Spawn_Hero(PoolType poolType)
    {
        Hero newHero = SimplePool.Spawn<Hero>(poolType, posSpawn_Hero.position, posSpawn_Hero.rotation);
        newHero.OnInit();
        if (coin >= newHero.GetCoinShopping)
        {
            coin -= newHero.GetCoinShopping;
            heros.Add(newHero);
        }
        else
        {
            newHero.OnDesPawn();
            print("Not Coint");
        }
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

    public void AddCoinOrUpdateCoin(int _coin)
    {
        coin += _coin;
        UIManager.Instance.GetUI<Canvas_GamePlay>().SetCoinText(coin);
    }

    public Sprite GetIconHero_Key(HeroType _heroType)
    {
        return iconHeros[_heroType];
    }

    public void AddAlliconToDis()
    {
        iconHeros[HeroType.HeroSword_1] = Resources.Load<Sprite>("HeroIcons/HeroSword_1");
        iconHeros[HeroType.Hero_AKM] = Resources.Load<Sprite>("HeroIcons/Hero_AKM");
    }
}
