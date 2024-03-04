using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelup_mng : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI nom;
    public hooman_mng hooman;
    public Animator anima;

    public void setup(hooman_mng mng)
    {
        hooman = mng;

        nom.text = hooman.hooman_info.nombre;

        int nivelactual = hooman.hooman_info.nivel - 1;
        lvl.text = nivelactual.ToString();

        anima.SetTrigger("go");
    }

    public void setup_lvl()
    {
        int lvlfinal = hooman.hooman_info.nivel;
        lvl.text = lvlfinal.ToString();
    }


}
