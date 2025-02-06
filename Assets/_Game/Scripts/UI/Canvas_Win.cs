using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Win : UICanvas
{
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