using System.Collections.Generic;
using UnityEngine;

public static class SimplePool
{
    private static Dictionary<PoolType, Pool> poolInsstance = new Dictionary<PoolType, Pool>();

    //khoi tao pool moi
    public static void Preload(GameUnit prefabs, int amount, Transform parent)
    {
        if (prefabs == null)
        {
            Debug.LogError("Prefabs Is Empty !!!");
            return;
        }

        if (!poolInsstance.ContainsKey(prefabs.PoolType) || poolInsstance[prefabs.PoolType] == null)
        {
            Pool p = new Pool();
            p.Preload(prefabs, amount, parent);
            poolInsstance[prefabs.PoolType] = p;
        }
    }

    //lay phan tu ra
    public static T Spawn<T>(PoolType poolType, Vector3 pos, Quaternion rot) where T : GameUnit
    {
        if (!poolInsstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + " Is Not Reload !!!");
            return null;
        }

        return poolInsstance[poolType].Spawn(pos, rot) as T;
    }

    //tra phan tu vao
    public static void Despawn(GameUnit unit)
    {
        if (!poolInsstance.ContainsKey(unit.PoolType))
        {
            Debug.LogError(unit.PoolType + " Is Not Reload !!!");
        }

        poolInsstance[unit.PoolType].Despawn(unit);
    }

    //thu thap phan tu
    public static void Collect(PoolType poolType)
    {
        if (!poolInsstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + " Is Not Reload !!!");
        }

        poolInsstance[poolType].Collect();
    }

    //thu thap tat ca
    public static void CollectAll()
    {
        foreach (var pool in poolInsstance.Values)
        {
            pool.Collect();
        }
    }

    //destroy 1 pool
    public static void Release(PoolType poolType)
    {
        if (!poolInsstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + " Is Not Reload !!!");
        }

        poolInsstance[poolType].Release();
    }

    //destroy tat ca
    public static void ReleaseAll()
    {
        foreach (var pool in poolInsstance.Values)
        {
            pool.Release();
        }
    }

}

public class Pool
{
    Transform parent;
    GameUnit prefabs; //moi pool can 1 prefabs


    Queue<GameUnit> inactives = new Queue<GameUnit>();//list chua cac unit dang o trong pool
    List<GameUnit> actives = new List<GameUnit>();//list chua cac unit dang duoc su dung


    //khoi tao pool
    public void Preload(GameUnit prefab, int amount, Transform parent)
    {
        this.parent = parent;
        this.prefabs = prefab;

        for (int i = 0; i < amount; i++)
        {
            Despawn(GameObject.Instantiate(prefabs, parent));
        }
    }

    //lay phan tu ra tu pool
    public GameUnit Spawn(Vector3 pos, Quaternion rot)
    {
        GameUnit unit;

        if (inactives.Count <= 0)
        {
            unit = GameObject.Instantiate(prefabs, parent);
        }
        else
        {
            unit = inactives.Dequeue();
        }

        unit.TF.SetLocalPositionAndRotation(pos, rot);
        actives.Add(unit);
        unit.gameObject.SetActive(true);
        return unit;
    }

    //lay phan tu vao trong pool
    public void Despawn(GameUnit unit)
    {
        if (unit != null && unit.gameObject.activeSelf)
        {
            actives.Remove(unit);
            inactives.Enqueue(unit);
            unit.gameObject.SetActive(false);
        }
    }

    // thu thap tat ca phan tu dang dung voi pool
    public void Collect()
    {
        while (inactives.Count > 0)
        {
            Despawn(actives[0]);
        }
    }

    //xoa phan tu dang dung
    public void Release()
    {
        Collect();
        while (inactives.Count > 0)
        {
            GameObject.Destroy(inactives.Dequeue().gameObject);
        }

        inactives.Clear();
    }
}