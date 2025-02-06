using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    int level;

    private void Start()
    {
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }

    public void OnInit()
    {
        //khoi tao cac thong so truoc khi bat dau man choi
    }

    public void OnPlay()
    {
        //bat dau man choi
    }

    public void LoadLevel(int level)
    {
        //load lai object trong man choi
    }

    public void OnWin()
    {
        //thang
    }

    public void OnLose()
    {
        //thua
    }

    public void OnNextLevel()
    {
        //next 1 level
        OnDespawn();
        LoadLevel(++level);
        OnInit();
    }

    public void OnRetryLevel()
    {
        //choi lai level
        OnDespawn();
        LoadLevel(level);
        OnInit();
    }

    public void OnDespawn()
    {
        //reset tat ca cac thong so cua man choi
    }

    public void CollectItem(AddDictionaryItem item)
    {
        //thu thap nhung thang item da hoan thanh
    }
}
