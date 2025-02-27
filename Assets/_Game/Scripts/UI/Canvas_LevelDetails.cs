using TMPro;
using UnityEngine;

public class Canvas_LevelDetails : UICanvas
{
    [SerializeField] int levelIndex;
    [SerializeField] Data_Level data_Level;

    [SerializeField] TextMeshProUGUI text_Level;

    [Header("Text Zombie Info")]
    [SerializeField] TextMeshProUGUI text_ZBFast;
    [SerializeField] TextMeshProUGUI text_ZBNormal;
    [SerializeField] TextMeshProUGUI text_ZBHard;
    [SerializeField] TextMeshProUGUI text_ZBBoss;
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
    }

    public void EditTeam_Button()
    {
        Close(0f);
        UIManager.Instance.OpenUI<Canvas_EditTeam>();
    }

    public void Play_Button()
    {
        LevelManager.Instance.LoadLevel(levelIndex);
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
        LevelManager.Instance.AddCoinOrUpdateCoin(0);
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