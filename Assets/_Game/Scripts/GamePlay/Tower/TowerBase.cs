using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : GameUnit
{
    [SerializeField] Canvas_HealthBar healthBar;
    [SerializeField] int hp;
    [SerializeField] bool IsDeath => hp <= 0;

    public virtual void OnInit(int _hp)
    {
        hp = _hp;
        healthBar.OnInit(hp);
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
            healthBar.SetNewHp(hp);
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
