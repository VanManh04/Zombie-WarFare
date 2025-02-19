using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_GamePlay : UICanvas
{
    [SerializeField] TextMeshProUGUI text_Coin;

    [Header("Spawn Button Slot Hero")]
    [SerializeField] Transform parentButtonSpawnHero;
    [SerializeField] Button buttonSpawnHeroUI;
    [SerializeField] List<Button_TeamHero> buttonSpawnHeros = new List<Button_TeamHero>();

    private void Load_ButtonSlotHero()
    {
        ClearButtonlevel();

        TeamHero teamHero = LevelManager.Instance.TeamHero;

        for (int i = 0; i < teamHero.GetCountHero; i++)
        {
            Button button = Instantiate(buttonSpawnHeroUI, parentButtonSpawnHero);

            Button_TeamHero button_TeamHero = button.GetComponent<Button_TeamHero>();
            HeroType heroType = teamHero.GetIndex(i);
            button_TeamHero.SetupIcon(LevelManager.Instance.GetIconHero_Key(heroType));

            PoolType poolType = (PoolType)heroType;
            buttonSpawnHeros.Add(button_TeamHero);

            button.onClick.AddListener(() => Event_BTN_SpawnHero(poolType));
            button.gameObject.SetActive(true);
        }
    }

    public void ClearButtonlevel()
    {
        for (int i = 0; i < buttonSpawnHeros.Count; i++)
            Destroy(buttonSpawnHeros[i].gameObject);

        buttonSpawnHeros.Clear();
    }

    public void Event_BTN_SpawnHero(PoolType _poolType)
    {
        LevelManager.Instance.Spawn_Hero(_poolType);
        LevelManager.Instance.AddCoinOrUpdateCoin(0);
    }

    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.GamePlay);
        Load_ButtonSlotHero();
    }

    public void Setting_Button()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this);
    }

    public void SetCoinText(int _coin)
    {
        text_Coin.text = "Coin: " + _coin.ToString();
    }
}