using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : TowerBase
{
    public override void OnInit(int _hp)
    {
        base.OnInit(_hp);
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        LevelManager.Instance.OnWin();
    }
}