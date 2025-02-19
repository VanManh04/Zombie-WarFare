using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Level", menuName = "Data/Data Level")]
public class Data_Level : ScriptableObject
{
    [SerializeField] bool unLock;
    [SerializeField] bool playDone;
    public bool GetUnlockLevel() => unLock;
    public void SetUnlockLevel(bool _unlock) => unLock = _unlock;
    public bool GetPlayDone() => playDone;
    public void SetPlayDone(bool _playDone) => playDone = _playDone;

    [Header("Homtown")]
    [SerializeField] int hp_Bus;
    [SerializeField] int hp_Barrier;

    [Header("Spawn Play Game")]
    [SerializeField] List<EnemyType> zombieFastS;
    [SerializeField] List<EnemyType> zombieNormalS;
    [SerializeField] List<EnemyType> zombieHardS;
    [SerializeField] List<EnemyType> zombieBossS;

    [SerializeField] bool canSpawm_ZB_Fast;
    public bool CanSpawm_ZB_Fast => canSpawm_ZB_Fast;
    [SerializeField] Vector2 timeSpawn_ZB_Fast;
    [Space(20)]
    [SerializeField] bool canSpawm_ZB_Normal;
    public bool CanSpawm_ZB_Normal => canSpawm_ZB_Normal;
    [SerializeField] Vector2 timeSpawn_ZB_Normal;
    [Space(20)]
    [SerializeField] bool canSpawm_ZB_Hard;
    public bool CanSpawm_ZB_Hard => canSpawm_ZB_Hard;
    [SerializeField] Vector2 timeSpawn_ZB_Hard;
    [Space(20)]
    [SerializeField] bool canSpawm_ZB_Boss;
    public bool CanSpawm_ZB_Boss => canSpawm_ZB_Boss;
    [SerializeField] Vector2 timeSpawn_ZB_Boss;

    [Header("End Wave Spawn")]
    [SerializeField] List<EnemyType> zombieSpawnEndWaveS;
    [Space(20)]
    [SerializeField] int count_ZB_EndWave;
    [SerializeField] Vector2 timeSpawn_ZB_EndWave;

    [SerializeField] float timeEndWaveZombie;

    public int RandomVector2(Vector2 _vector2) => Random.Range((int)_vector2.x, (int)_vector2.y);

    public float GetTimeSpawn_ZB_Fast() => RandomVector2(timeSpawn_ZB_Fast);
    public float GetTimeSpawn_ZB_Normal() => RandomVector2(timeSpawn_ZB_Normal);
    public float GetTimeSpawn_ZB_Hard() => RandomVector2(timeSpawn_ZB_Hard);
    public float GetTimeSpawn_ZB_Boss() => RandomVector2(timeSpawn_ZB_Boss);
    public float GetTimeSpawn_ZB_EndWave() => RandomVector2(timeSpawn_ZB_EndWave);
    public float GetTimeSpawn_EndWaveZombie() => timeEndWaveZombie;
    public int GetCount_ZB_EndWaveZombie() => count_ZB_EndWave;

    public PoolType Random_ZB_Fast()
    {
        int index = Random.Range(0, zombieFastS.Count);
        PoolType selectedPool = (PoolType)zombieFastS[index];
        return selectedPool;
    }
    public PoolType Random_ZB_Normal()
    {
        int index = Random.Range(0, zombieNormalS.Count);
        PoolType selectedPool = (PoolType)zombieNormalS[index];
        return selectedPool;
    }
    public PoolType Random_ZB_Hard()
    {
        int index = Random.Range(0, zombieHardS.Count);
        PoolType selectedPool = (PoolType)zombieHardS[index];
        return selectedPool;
    }
    public PoolType Random_ZB_Boss()
    {
        int index = Random.Range(0, zombieBossS.Count);
        PoolType selectedPool = (PoolType)zombieBossS[index];
        return selectedPool;
    }

    public PoolType Random_ZB_EndWave()
    {
        int index = Random.Range(0, zombieSpawnEndWaveS.Count);
        PoolType selectedPool = (PoolType)zombieSpawnEndWaveS[index];
        return selectedPool;
    }
    public int Get_HpBus() => hp_Bus;
    public int Get_HpBarrier() => hp_Barrier;
}