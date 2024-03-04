using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class warning_mng : MonoBehaviour
{
    public TextMeshProUGUI warning_titulo;
    public TextMeshProUGUI warning_desc;
    public Image icon;
    public Animator anima;


    public void setup(Color col, string desc, Sprite sprite1)
    {
        warning_titulo.color = col;
        warning_desc.text = desc;
        icon.sprite = sprite1;

        anima.SetTrigger("go");
    }

}
