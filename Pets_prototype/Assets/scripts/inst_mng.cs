using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inst_mng : MonoBehaviour
{
    public drop_zone drop;
    public TextMeshProUGUI inst_nom;


    private void Start()
    {
        if(drop)
        {
            inst_nom.text = drop.inst.nombre;
        }
    }

}
