using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_TeamHero : MonoBehaviour
{
    [SerializeField] Button button_this;
    [SerializeField] Image imageCooldown;
    [SerializeField] Image imageIcon;
    [SerializeField] HeroType heroType;

    public void SetupIcon(Sprite sprite)
    {
        //imageIcon = GetComponent<Image>();
        imageIcon.sprite = sprite;
    }

    public void SetupHeroType(HeroType _heroType)
    {
        heroType = _heroType;
    }

    public HeroType GetHeroType() => heroType;
    public Button GetButtonThis() => button_this;
    public Image GetImageCooldownThis() => imageCooldown;
}
