using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Setting : UICanvas
{
    [SerializeField] GameObject[] buttons;

    public void SetState(UICanvas canvas)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        if (canvas is Canvas_Menu)
        {
            buttons[2].gameObject.SetActive(true);
        }
        else if (canvas is Canvas_GamePlay)
        {
            buttons[1].gameObject.SetActive(true);
            buttons[0].gameObject.SetActive(true);
        }
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }
}