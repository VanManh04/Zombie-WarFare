using UnityEngine;
using UnityEngine.UI;

public class Canvas_HealthBar : MonoBehaviour
{
    [SerializeField] Image imageFill;

    Camera _camera;

    float hp;
    float maxHP;

    Vector3 posCamCaculator;
    void Start()
    {
        _camera = Camera.main;
        posCamCaculator = _camera.transform.position;
    }

    void Update()
    {
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp / maxHP, Time.deltaTime * 5f);
        
        posCamCaculator = new Vector3(transform.position.x, posCamCaculator.y, transform.position.z);
        transform.rotation = Quaternion.LookRotation(transform.position - posCamCaculator);


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