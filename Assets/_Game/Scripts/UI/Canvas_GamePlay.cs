using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_GamePlay : UICanvas
{
    [SerializeField] TextMeshProUGUI text_Coin;

    [Header("Spawn Button Slot Hero")]
    [SerializeField] Transform parentButtonSpawnHero;
    [SerializeField] Button_TeamHero buttonSpawnHeroUI;
    [SerializeField] List<Button_TeamHero> buttonSpawnHeros = new List<Button_TeamHero>();

    [Header("Coundown Spawn Hero")]
    [SerializeField] Data_CoundownSpawnHero data_CoundownSpawn;
    [SerializeField] float[] coundownSpawnHero;
    [SerializeField] bool[] canSpawn;

    [Header("Text pop up")]
    [SerializeField] PopUpTextFX textCooldown;
    [SerializeField] PopUpTextFX textNotCoint;
    [SerializeField] Transform posSpawn;

    public override void Open()
    {
        FadeOut_Main();
        base.Open();

        GameManager.Instance.ChangeGameState(GameState.GamePlay);
        Load_ButtonSlotHero();

        //load time coundown
        LoadTimeeCoundownAndAddEvent();
    }

    private void LoadTimeeCoundownAndAddEvent()
    {
        data_CoundownSpawn = LevelManager.Instance.GetData_CoundownSpawnHero;
        canSpawn = new bool[buttonSpawnHeros.Count];
        coundownSpawnHero = new float[buttonSpawnHeros.Count];

        for (int i = 0; i < coundownSpawnHero.Length; i++)
        {
            //print(buttonSpawnHeros[i].GetHeroType());
            canSpawn[i] = true;
            coundownSpawnHero[i] = data_CoundownSpawn.GetTimeSpawnHero(buttonSpawnHeros[i].GetHeroType());
        }

        for (int i = 0; i < buttonSpawnHeros.Count; i++)
        {
            Image image = buttonSpawnHeros[i].GetImageCooldownThis();
            float cooldown = coundownSpawnHero[i];
            int index = i;
            PoolType poolType = (PoolType)buttonSpawnHeros[i].GetHeroType();
            buttonSpawnHeros[i].GetButtonThis().onClick.AddListener(() => ALL_Envent_BTN(index, poolType, image, cooldown));
        }
    }

    private void Load_ButtonSlotHero()
    {
        ClearButtonlevel();

        TeamHero teamHero = LevelManager.Instance.TeamHero;

        for (int i = 0; i < teamHero.GetCountHero; i++)
        {
            Button_TeamHero button_TeamHero = Instantiate(buttonSpawnHeroUI, parentButtonSpawnHero);
            HeroType heroType = teamHero.GetIndex(i);
            //setup
            button_TeamHero.SetupIcon(LevelManager.Instance.GetIconHero_Key(heroType));
            button_TeamHero.SetupHeroType(heroType);

            buttonSpawnHeros.Add(button_TeamHero);

            button_TeamHero.gameObject.SetActive(true);
        }
    }

    public void ClearButtonlevel()
    {
        for (int i = 0; i < buttonSpawnHeros.Count; i++)
            Destroy(buttonSpawnHeros[i].gameObject);

        buttonSpawnHeros.Clear();
    }

    public void Setting_Button()
    {
        UIManager.Instance.OpenUI<Canvas_Setting>().SetState(this);
    }

    public void SetCoinText(int _coin)
    {
        text_Coin.text = "Coin: " + _coin.ToString();
    }

    private void ALL_Envent_BTN(int _index_BTN, PoolType _poolType, Image _image, float _coolDown)
    {
        if (canSpawn[_index_BTN])
        {
            if (LevelManager.Instance.Spawn_Hero(_poolType))
            {
                StartCoroutine(IECoundownSpawnHero(_index_BTN, _image, _coolDown));
                LevelManager.Instance.UpdateCoin();
            }
            else
            {
                SimplePool.Spawn<PopUpTextFX>(PoolType.PopUpText_NotCoint, posSpawn.position, posSpawn.rotation);
                //print("not coint");
            }
        }
        else
        {
                SimplePool.Spawn<PopUpTextFX>(PoolType.PopUpText_Cooldown, posSpawn.position, posSpawn.rotation);
            //print("Coundown");
        }

    }

    IEnumerator IECoundownSpawnHero(int _index_BTN, Image _image, float _cooldown)
    {
        SetCooldownOf(_image);
        canSpawn[_index_BTN] = false;
        float timeCount = 0;
        while (timeCount < _cooldown)
        {
            timeCount += Time.deltaTime;
            _image.fillAmount = Mathf.Clamp01(1 - (timeCount / _cooldown));

            yield return null;
        }
        _image.fillAmount = 0;
        canSpawn[_index_BTN] = true;
    }

    private void SetCooldownOf(Image _image)
    {
        if (_image.fillAmount <= 0)
            _image.fillAmount = 1;
    }
}