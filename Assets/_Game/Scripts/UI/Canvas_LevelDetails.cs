using TMPro;
using UnityEngine;

public class Canvas_LevelDetails : UICanvas
{
    //them anim
    [SerializeField] Animator anim;
    public void FadeInLevelDetails()
    {
        if (anim != null)
            anim.SetTrigger(Constants.ANIM_UI_FadeIn);
        else
            print("none Animator");

        //print("FadeIn");
    }

    public void FadeOutLevelDetails()
    {
        if (anim != null)
            anim.SetTrigger(Constants.ANIM_UI_FadeOut);
        else
            print("none Animator");
        //print("FadeOut");
    }

    //logic 
    [SerializeField] int levelIndex;
    [SerializeField] Data_Level data_Level;

    [SerializeField] TextMeshProUGUI text_Level;

    [Header("Text Zombie Info")]
    [SerializeField] TextMeshProUGUI text_ZBFast;
    [SerializeField] TextMeshProUGUI text_ZBNormal;
    [SerializeField] TextMeshProUGUI text_ZBHard;
    [SerializeField] TextMeshProUGUI text_ZBBoss;

    private void Awake()
    {
        if (anim != null)
            anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public override void Open()
    {
        FadeInLevelDetails();
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
    }
    public void Close_Anim()
    {
        FadeOutLevelDetails();
        
        DelayMethod(.31f,CloseDirectly);
    }

    public void EditTeam_Button()
    {
        Close_Anim();
        UIManager.Instance.OpenUI<Canvas_EditTeam>();
    }

    public void Play_Button()
    {
        FadeIn_Main();
        LevelManager.Instance.LoadLevel(levelIndex);
        DelayMethod(.4f, Play_Button_Logic);
    }

    private static void Play_Button_Logic()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
        LevelManager.Instance.UpdateCoin();
        //load level.....
    }

    public void SetUpLevel(int _levelIndex, Data_Level _data_Level)
    {
        levelIndex = _levelIndex;
        data_Level = _data_Level;
        text_Level.text = "Level: " + (levelIndex + 1).ToString();
        text_ZBFast.text = "Zombie Fast: " + data_Level.CanSpawm_ZB_Fast.ToString();
        text_ZBNormal.text = "Zombie Normal: " + data_Level.CanSpawm_ZB_Normal.ToString();
        text_ZBHard.text = "Zombie Hard: " + data_Level.CanSpawm_ZB_Hard.ToString();
        text_ZBBoss.text = "Zombie Boss: " + data_Level.CanSpawm_ZB_Boss.ToString();
    }
}