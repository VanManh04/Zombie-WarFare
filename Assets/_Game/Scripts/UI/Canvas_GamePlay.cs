using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_GamePlay : UICanvas
{
    public void Setting_Button()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this);
    }

    public void Spawn_Hero_1()
    {
        print("Spawn Hero 1");
        LevelManager.Instance.Spawn_Hero(PoolType.HeroSword_1);
    }

    public void Spawn_Hero_2()
    {
        print("Spawn Hero 2");
        LevelManager.Instance.Spawn_Hero(PoolType.Hero_AKM);
    }

    public void Spawn_Hero_3()
    {
        print("Spawn Hero 3");
    }
}