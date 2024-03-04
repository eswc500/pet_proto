using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class need_mng : MonoBehaviour
{
    public TextMeshProUGUI nom;
    public TextMeshProUGUI desc;

    public Image bar;
    public TextMeshProUGUI qty;
    public Image icon;
    public Animator anima;


    public void setup(string nomb, string descc, int id1, int qty1, Color col1, Sprite sprite1)
    {
        nom.text = nomb;
        desc.text = descc;

        qty.text = "-" + qty1.ToString();

        bar.color = col1;
        icon.sprite = sprite1;

        anima.SetTrigger("go");
    }
}
