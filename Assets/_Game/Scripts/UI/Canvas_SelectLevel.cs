using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_SelectLevel : UICanvas
{
    public void Play_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }
}