using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Lose : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Lose);
    }

    public void Replay_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();

        LevelManager.Instance.OnRetryLevel();
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }
}