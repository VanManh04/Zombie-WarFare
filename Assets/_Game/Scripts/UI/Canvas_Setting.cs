using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Canvas_Setting : UICanvas
{
    //them anim
    [SerializeField] Animator anim;
    public void FadeInSetting()
    {
        if (anim != null)
            anim.SetTrigger(Constants.ANIM_UI_FadeIn);
        else
            print("none Animator");

        //print("FadeIn");
    }

    public void FadeOutSetting()
    {
        if (anim != null)
            anim.SetTrigger(Constants.ANIM_UI_FadeOut);
        else
            print("none Animator");
        //print("FadeOut");
    }

    //button
    [SerializeField] GameObject[] buttons;
    GameState gameStateOld;

    private void Awake()
    {
        if (anim != null)
            anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public override void Open()
    {
        FadeInSetting();
        base.Open();
        gameStateOld = GameManager.Instance.GetGameState();
        GameManager.Instance.ChangeGameState(GameState.Pause);
    }

    public override void Close(float _time)
    {
        FadeOutSetting();        
        base.Close(_time);
        DelayMethod(.4f,Close_logic);
    }
    void Close_logic()
    {
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
        FadeIn_Main();
        DelayMethod(.31f, Menu_Button_Logic);
    }

    public void Menu_Button_Logic()
    {
        UIManager.Instance.CloseAll();//change gamestate old
        UIManager.Instance.OpenUI<Canvas_Menu>();//change game state menu

        //Clear all data level
        LevelManager.Instance.OnDespawn();
        LevelManager.Instance.OnInit();
    }

    public void Replay_Button()
    {
        FadeIn_Main();
        DelayMethod(.31f, Replay_Button_Logic);
    }
    public void Replay_Button_Logic()
    {
        CloseDirectly();
        //UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
        LevelManager.Instance.OnRetryLevel();
    }
}