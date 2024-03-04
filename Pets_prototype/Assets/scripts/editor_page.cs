using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class editor_page : MonoBehaviour
{
    public List<TMP_InputField> test;

    public void get_text(string texto, TMP_InputField input)
    {
        //input.placeholder.GetComponent<TextMeshProUGUI>().text = "Ingrese su texto aquí";
        input.text = texto;
    }

    


}
