using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isDestroyOnClase = false;

    private void Awake()
    {
        //xu ly tai tho
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if (ratio > 2.1f)
        {
            Vector2 leftBotton = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;

            leftBotton.y = 0f;
            rightTop.y = -100f;

            rect.offsetMin = leftBotton;
            rect.offsetMax = rightTop;
        }
    }

    //goi truoc khi canvas duoc active
    public virtual void Setup()
    {

    }

    //goi sau khi canvas duoc active
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    //tat canvas sau time (s)
    public virtual void Close(float _time)
    {
        Invoke(nameof(CloseDirectly), _time);
    }

    //tat canvas truc tiep
    public virtual void CloseDirectly()
    {
        if (isDestroyOnClase)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Quit_Button()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif

    }
}
