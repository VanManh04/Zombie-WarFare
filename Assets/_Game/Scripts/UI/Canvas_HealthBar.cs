using UnityEngine;
using UnityEngine.UI;

public class Canvas_HealthBar : MonoBehaviour
{
    [SerializeField] Image imageFill;

    Camera _camera;

    float hp;
    float maxHP;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHP, Time.deltaTime * 5f);
        transform.Rotate(20,-90,0);
        //transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);


        //transform.position = target.position + offset;
    }

    public void OnInit(float maxHP)
    {
        this.maxHP = maxHP;
        hp = maxHP;
        imageFill.fillAmount = 1;
    }

    public void SetNewHp(float hp)
    {
        this.hp = hp;

        //imageFill.fillAmount = hp/maxHP;
    }
}