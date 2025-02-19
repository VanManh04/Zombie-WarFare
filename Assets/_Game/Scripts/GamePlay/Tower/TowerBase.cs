using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : GameUnit
{
    [SerializeField] int hp;
    [SerializeField] bool IsDeath => hp <= 0;

    public virtual void OnInit(int _hp)
    {
        hp = _hp;
    }

    public void OnHit(int _damage)
    {
        if (!IsDeath)
        {
            hp -= _damage;

            if (IsDeath)
            {
                OnDeath();
            }
        }
    }

    protected virtual void OnDeath()
    {
        //Destroy(gameObject);
        
        SimplePool.Despawn(this);
    }

    public void OnDespawn()
    {
        
    }
}
