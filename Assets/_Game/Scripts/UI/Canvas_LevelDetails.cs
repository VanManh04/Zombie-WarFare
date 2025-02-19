using TMPro;
using UnityEngine;

public class Canvas_LevelDetails : UICanvas
{
    [SerializeField] int levelIndex;
    [SerializeField] Data_Level data_Level;

    [SerializeField] TextMeshProUGUI text_Level;
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
        SetLevelText(levelIndex + 1);
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

    private void SetLevelText(int _level)
    {
        text_Level.text = _level.ToString();
    }

    public void SetUpLevel(int _levelIndex, Data_Level _data_Level)
    {
        levelIndex = _levelIndex;
        data_Level = _data_Level;
    }
}