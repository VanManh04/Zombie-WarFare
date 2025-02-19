using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_EditTeam : UICanvas
{
    [Header("Team Hero")]
    [SerializeField] TeamHero teamHero;

    [Header("Spawn Button Slot Hero")]
    [SerializeField] Transform parentButtonSlotHero;
    [SerializeField] Button buttonSlotHeroUI;
    [SerializeField] List<Button_TeamHero> buttonSlotHeros = new List<Button_TeamHero>();

    [Header("Spawn Button HeroChange")]
    [SerializeField] Transform UIHeroChange;
    [SerializeField] Transform parentButtonHeroChange;
    [SerializeField] Button buttonHeroChangeUI;
    [SerializeField] List<Button_TeamHero> buttonHeroChanges = new List<Button_TeamHero>();
    [SerializeField] List<HeroType> heroTypes = new List<HeroType>();

    [Header("Change Hero")]
    int indexSlotHeroChange;
    HeroType heroTypeChange;

    private void Awake()
    {
        OnInit();
    }

    private void OnInit()
    {
        teamHero = LevelManager.Instance.TeamHero;
        Load_ButtonSlotHero();
        AddAllHeroTypeTolist();
        Load_ButtonHeroChange();
    }

    private void AddAllHeroTypeTolist()=>heroTypes = Enum.GetValues(typeof(HeroType)).Cast<HeroType>().ToList();

    private void Load_ButtonSlotHero()
    {
        ClearButtonlevel();

        TeamHero teamHero = LevelManager.Instance.TeamHero;

        for (int i = 0; i < teamHero.GetCountHero; i++)
        {
            Button button = Instantiate(buttonSlotHeroUI, parentButtonSlotHero);

            Button_TeamHero button_TeamHero = button.GetComponent<Button_TeamHero>();
            HeroType heroType = teamHero.GetIndex(i);
            button_TeamHero.SetupHeroType(heroType);
            button_TeamHero.SetupIcon(LevelManager.Instance.GetIconHero_Key(heroType));
            buttonSlotHeros.Add(button_TeamHero);
            int y = i;
            button.onClick.AddListener(() => Event_BTN_SlotHero(y));
            button.gameObject.SetActive(true);
        }
    }

    private void Load_ButtonHeroChange()
    {
        for (int i = 0; i < heroTypes.Count; i++)
        {
            Button button = Instantiate(buttonHeroChangeUI, parentButtonHeroChange);

            Button_TeamHero button_TeamHero = button.GetComponent<Button_TeamHero>();
            HeroType heroType = heroTypes[i];
            button_TeamHero.SetupHeroType(heroType);

            button_TeamHero.SetupIcon(LevelManager.Instance.GetIconHero_Key(heroType));

            buttonHeroChanges.Add(button_TeamHero);

            button.onClick.AddListener(() => Event_BTN_ChangeHero(heroType)); //chage
            button.gameObject.SetActive(true);
        }
    }

    public void ClearButtonlevel()
    {
        for (int i = 0; i < buttonSlotHeros.Count; i++)
            Destroy(buttonSlotHeros[i].gameObject);

        buttonSlotHeros.Clear();
    }

    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeGameState(GameState.Menu);
    }

    public void Event_BTN_SlotHero(int _indexHero)
    {
        //Debug.Log(_heroType.ToString());
        indexSlotHeroChange = _indexHero;
        OpenUIHeroChange();
    }

    public void Event_BTN_ChangeHero(HeroType _heroType)
    {
        teamHero.ChangeheroList(indexSlotHeroChange, _heroType);
        Load_ButtonSlotHero();
        CloseUIHeroChange();
        //Change Hero
    }

    public void Menu_Button()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Menu>();
    }

    public void CloseUIHeroChange()
    {
        UIHeroChange.gameObject.SetActive(false);
    }

    public void OpenUIHeroChange()
    {
        UIHeroChange.gameObject.SetActive(true);
    }
}