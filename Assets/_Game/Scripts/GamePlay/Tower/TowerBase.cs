using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] bool IsDeath => hp <= 0;


    protected virtual void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {

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
        print("Death: "+gameObject.name);
        //Destroy(gameObject);
        this.gameObject.SetActive(false);
    }
}
