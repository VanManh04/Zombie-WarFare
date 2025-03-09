using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpTextFX : GameUnit
{
    [SerializeField]TextMeshPro text;

    [SerializeField] float speed;
    [SerializeField] float desaperanceSpeed;
    [SerializeField] float colorDesapearanceSpeed;

    [SerializeField] float lifeTime;
    float textTimer;
    Color colorDefault;


    private void Start()
    {
        colorDefault = text.color;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    private void Update()
    {
        TF.position = Vector2.MoveTowards(TF.position, new Vector2(TF.position.x, TF.position.y + 1), speed * Time.deltaTime);
        textTimer += Time.deltaTime;

        if (textTimer >= lifeTime)
        {
            float alpha = text.color.a - colorDesapearanceSpeed * Time.deltaTime;

            text.color = new Color(text.color.r,text.color.g,text.color.b,alpha);

            if(text.color.a<50)
                speed = desaperanceSpeed;

            if (text.color.a <= 0)
                OnDespawn();
        }
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
        text.color = colorDefault;
    }
}
