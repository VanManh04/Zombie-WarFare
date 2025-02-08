using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Win : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Win);
    }

    public void NextLevel_Button()
    {
        print("Next Level");
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }
}