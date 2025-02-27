using UnityEngine;

public class PoolControl : MonoBehaviour
{
    [SerializeField] PoolAmount[] poolAmounts;

    void Awake()
    {

        //load tu list
        for (int i = 0; i < poolAmounts.Length; i++)
        {
            SimplePool.Preload(poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].parent);
        }
        ///load tu resource 
        GameUnit[] gameUnits = Resources.LoadAll<GameUnit>("Pool/");

        for (int i = 0; i < gameUnits.Length; i++)
        {
            SimplePool.Preload(gameUnits[i], 0, new GameObject(gameUnits[i].name).transform);
        }

    }
}

[System.Serializable]
public class PoolAmount
{
    public GameUnit prefab;
    public Transform parent;
    public int amount;
}

public enum PoolType
{
    Projectile = 0,
    CasingBullet = 1,
    ZombieFast_1 = 2,
    Zombie_Creep1 = 3,
    Zombie_Creep2 = 4,
    Zombie_Creep3 = 5,
    HeroSword_1 = 6,
    Hero_AKM = 7,
    Bus = 8,
    Barrier = 9,
    Monster_X=10,
    HeroSword_2 = 11,
    Blood_1=12,
    Blood_3=13,
    Blood_4=14,
    Blood_5=15,
    Blood_6=16,
    Blood_7=17,
    Blood_8=18,
    Blood_9=19,
    Blood_10=20,
    Blood_11=21,
    Blood_12=22,
    Blood_13=23,
    Blood_14=24,
    Blood_15=25,
}