using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieManager : Singleton<SpawnZombieManager>
{
    Data_Level data_Level;

    [SerializeField] List<Zombie> zombies = new List<Zombie>();

    [SerializeField] BoxCollider boxRandomPosSpawn;

    float timerSpawnZB_Fast;
    float timerSpawnZB_Normal;
    float timerSpawnZB_Hard;
    float timerSpawnZB_Boss;

    float timerEndWave;

    public void OnInit()
    {
        data_Level = LevelManager.Instance.GetDataLevel;
        timerSpawnZB_Fast = data_Level.GetTimeSpawn_ZB_Fast();
        timerSpawnZB_Normal = data_Level.GetTimeSpawn_ZB_Normal();
        timerSpawnZB_Hard = data_Level.GetTimeSpawn_ZB_Hard();
        timerSpawnZB_Boss = data_Level.GetTimeSpawn_ZB_Boss();
        timerEndWave = data_Level.GetTimeSpawn_ZB_EndWave();
    }

    void Update()
    {
        if (GameManager.Instance.GetGameState() != GameState.GamePlay||LevelManager.Instance.GetBus==null)
            return;
        timerEndWave -= Time.deltaTime;

        if (data_Level.CanSpawm_ZB_Fast)
        {
            timerSpawnZB_Fast -= Time.deltaTime;
            if (timerSpawnZB_Fast <= 0)
            {
                Zombie newZombie = SimplePool.Spawn<Zombie>(data_Level.Random_ZB_Fast(), GetRandomPositionInBox(), boxRandomPosSpawn.transform.rotation);
                newZombie.OnInit();
                zombies.Add(newZombie);
                timerSpawnZB_Fast = data_Level.GetTimeSpawn_ZB_Fast();
            }
        }

        if (data_Level.CanSpawm_ZB_Normal)
        {
            timerSpawnZB_Normal -= Time.deltaTime;
            if (timerSpawnZB_Normal <= 0)
            {
                Zombie newZombie = SimplePool.Spawn<Zombie>(data_Level.Random_ZB_Normal(), GetRandomPositionInBox(), boxRandomPosSpawn.transform.rotation);
                newZombie.OnInit();
                zombies.Add(newZombie);
                timerSpawnZB_Normal = data_Level.GetTimeSpawn_ZB_Normal();
            }
        }

        if (data_Level.CanSpawm_ZB_Hard)
        {
            timerSpawnZB_Hard -= Time.deltaTime;
            if (timerSpawnZB_Hard <= 0)
            {
                Zombie newZombie = SimplePool.Spawn<Zombie>(data_Level.Random_ZB_Hard(), GetRandomPositionInBox(), boxRandomPosSpawn.transform.rotation);
                newZombie.OnInit();
                zombies.Add(newZombie);
                timerSpawnZB_Hard = data_Level.GetTimeSpawn_ZB_Hard();
            }

        }

        if (data_Level.CanSpawm_ZB_Boss)
        {
            timerSpawnZB_Boss -= Time.deltaTime;
            if (timerSpawnZB_Boss <= 0)
            {
                Zombie newZombie = SimplePool.Spawn<Zombie>(data_Level.Random_ZB_Boss(), GetRandomPositionInBox(), boxRandomPosSpawn.transform.rotation);
                newZombie.OnInit();
                zombies.Add(newZombie);
                timerSpawnZB_Boss = data_Level.GetTimeSpawn_ZB_Boss();
            }
        }

        if (timerEndWave <= 0)
        {
            timerEndWave = float.MaxValue;
            StartCoroutine(IESpawnZombieEndWave());
        }
    }

    public void OnDespawn()
    {
        foreach (var item in zombies)
        {
            Destroy(item.gameObject);
        }
        zombies.Clear();
    }

    IEnumerator IESpawnZombieEndWave()
    {
        int count_ZB = data_Level.GetCount_ZB_EndWaveZombie();
        for (int i = 0; i < count_ZB; i++)
        {
            Zombie newZombie = SimplePool.Spawn<Zombie>(data_Level.Random_ZB_EndWave(), GetRandomPositionInBox(), boxRandomPosSpawn.transform.rotation);
            newZombie.OnInit();
            zombies.Add(newZombie);
            yield return new WaitForSeconds(data_Level.GetTimeSpawn_ZB_EndWave());
        }
        timerEndWave = data_Level.GetTimeSpawn_EndWaveZombie();
    }

    public Vector3 GetRandomPositionInBox()
    {
        if (boxRandomPosSpawn == null)
        {
            return Vector3.zero;
        }

        Vector3 size = boxRandomPosSpawn.size;
        Vector3 center = boxRandomPosSpawn.transform.position + boxRandomPosSpawn.center;

        float randomX = Random.Range(-0.5f, 0.5f) * size.x;
        float randomY = Random.Range(-0.5f, 0.5f) * size.y;
        float randomZ = Random.Range(-0.5f, 0.5f) * size.z;

        return center + new Vector3(randomX, randomY, randomZ);
    }
}
