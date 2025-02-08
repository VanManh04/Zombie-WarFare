using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Menu : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
    }

    public void Play_Button()
    {
        Close(0f);
        UIManager.Instance.OpenUI<Canvas_SelectLevel>();
    }

    public void Setting_Button()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this);
    }
}