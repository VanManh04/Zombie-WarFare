using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_SelectLevel : UICanvas
{
    [Header("Spawn Button Level")]
    [SerializeField] Transform parentButtonLevel;
    [SerializeField] Button buttonLevelUI;
    [SerializeField] List<GameObject> buttonLevels = new List<GameObject>();

    private void Load_ButtonLevel()
    {
        Data_Level[] levels = LevelManager.Instance.GetArrayDataLevel();
        for (int i = 0; i < levels.Length; i++)
        {
            int _tempIndex = i;
            Button button = Instantiate(buttonLevelUI, parentButtonLevel);

            buttonLevels.Add(button.gameObject);

            LevelDetails LevelDetails = button.GetComponent<LevelDetails>();
            LevelDetails.SetLevelIndex(i);
            LevelDetails.SetTextButtonLevel((i + 1).ToString());
            LevelDetails.SetUnLockLevel(levels[i].GetUnlockLevel());
            if (levels[i].GetUnlockLevel())
                button.onClick.AddListener(() => Event_ShowLevelDetails_ButtonLevel(_tempIndex));
            button.gameObject.SetActive(true);
        }
    }

    public void ClearButtonlevel()
    {
        for (int i = 0; i < buttonLevels.Count; i++)
            Destroy(buttonLevels[i]);

        buttonLevels.Clear();
    }

    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
        ClearButtonlevel();
        Load_ButtonLevel();
    }

    public void Event_ShowLevelDetails_ButtonLevel(int _indexLevel)
    {
        //UIManager.Instance.CloseUI<Canvas_LevelDetails>(0f);
        Canvas_LevelDetails canvas_LevelDetails = UIManager.Instance.GetUI<Canvas_LevelDetails>();
        //canvas_LevelDetails.Close(0f);
        canvas_LevelDetails.SetUpLevel(_indexLevel, LevelManager.Instance.GetDataLevel_Index(_indexLevel));
        canvas_LevelDetails.Open();
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }
}