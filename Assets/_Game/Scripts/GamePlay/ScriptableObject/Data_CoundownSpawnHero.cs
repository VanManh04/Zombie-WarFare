using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "Data Coundown Spawn Hero", menuName = "Data/Data Coundown Spawn Hero")]
public class Data_CoundownSpawnHero : ScriptableObject
{
    [Header("Hero[i] = Time[i]")]
    [SerializeField] HeroType[] heroTypes;
    [SerializeField] int[] timeSpawn;
    Dictionary<HeroType, int> timeSpawnHero = new Dictionary<HeroType, int>();

    private void OnValidate()
    {
        RenderDictionary();
    }

    private void RenderDictionary()
    {
        timeSpawnHero.Clear();
        if (timeSpawn.Length != heroTypes.Length)
        {
            Debug.LogError("Erro Count List TimeSpawn or Hero");
        }

        for (int i = 0; i < heroTypes.Length; i++)
        {
            timeSpawnHero.Add(heroTypes[i], timeSpawn[i]);
        }
        Debug.Log(heroTypes.Length);
    }

    public float GetTimeSpawnHero(HeroType heroType) => timeSpawnHero[heroType];

    [ContextMenu("ReLoad Array HeroType")]
    public void ReLoad_ArrayHeroType()
    {
        heroTypes = Enum.GetValues(typeof(HeroType)).Cast<HeroType>().ToArray();
    }
}