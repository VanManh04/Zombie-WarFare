using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Menu : UICanvas
{
    public override void Open()
    {
        base.Open();
        FadeOut_Main();
        GameManager.Instance.ChangeGameState(GameState.Menu);
    }

    public override void CloseDirectly()
    {
        base.CloseDirectly();
    }

    public void Play_Button()
    {
        FadeIn_Main();
        DelayMethod(.4f,DelayPlay_Button);
    }

    public void DelayPlay_Button()
    {
        Close(0f);
        UIManager.Instance.OpenUI<Canvas_SelectLevel>();
    }

    public void Setting_Button()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this);
    }
}