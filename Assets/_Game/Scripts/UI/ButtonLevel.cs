using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_Level;
    [SerializeField] Image image_LockLevel;

    public void SetUnLockLevel(bool Locked)
    {
        image_LockLevel.gameObject.SetActive(!Locked);
    }

    public void SetTextButtonLevel(string _text)
    {
        text_Level.text = _text;
    }
}
