using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Setting : UICanvas
{
    [SerializeField] GameObject[] buttons;
    GameState gameStateOld;

    public override void Open()
    {
        base.Open();
        gameStateOld = GameManager.Instance.GetGameState();
        GameManager.Instance.ChangeGameState(GameState.Pause);
    }

    public override void Close(float _time)
    {
        base.Close(_time);
        GameManager.Instance.ChangeGameState(gameStateOld);
    }

    public void SetState(UICanvas canvas)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        if (canvas is Canvas_Menu)
        {
            buttons[3].gameObject.SetActive(true);
        }
        else if (canvas is Canvas_GamePlay)
        {
            buttons[2].gameObject.SetActive(true);
            buttons[1].gameObject.SetActive(true);
            buttons[0].gameObject.SetActive(true);
        }
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();//change gamestate old
        UIManager.Instance.OpenUI<Canvas_Menu>();//change game state menu

        //Clear all data level
        LevelManager.Instance.OnDespawn();
        LevelManager.Instance.OnInit();
    }

    public void Replay_Button()
    {
        CloseDirectly();
        //UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();

        LevelManager.Instance.OnRetryLevel();
    }
}