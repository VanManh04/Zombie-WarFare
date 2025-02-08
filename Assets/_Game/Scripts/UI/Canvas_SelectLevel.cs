using UnityEngine;
using UnityEngine.UI;

public class Canvas_SelectLevel : UICanvas
{
    [Header("Spawn Button Level")]
    [SerializeField] Transform parentButtonLevel;
    [SerializeField] Button buttonLevelUI;

    void Start()
    {
        Data_Level[] levels = LevelManager.Instance.GetArrayDataLevel();
        for (int i = 0; i < levels.Length; i++)
        {
            int _tempIndex = i;
            Button button = Instantiate(buttonLevelUI, parentButtonLevel);
            ButtonLevel buttonLevel = button.GetComponent<ButtonLevel>();
            buttonLevel.SetTextButtonLevel((i + 1).ToString());
            buttonLevel.SetUnLockLevel(levels[i].GetUnlockLevel());
            if (levels[i].GetUnlockLevel())
                button.onClick.AddListener(() => Play_Button(_tempIndex));
            button.gameObject.SetActive(true);
        }
    }

    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
    }

    public void Play_Button(int _indexLevel)
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
        //load level....
        LevelManager.Instance.LoadLevel(_indexLevel);
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }
}