using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class level_options : MonoBehaviour
{
    public GameObject prefab;
    public Transform origin;
    public editor_page editor;

    public void setup(SO_GameInfo game)
    {
        if(editor.test.Count == 0)
        {
            for (int i = 0; i < game.nivel_req.Count; i++)
            {
                GameObject obj = Instantiate(prefab, origin);

                level_option_obj obj2 = obj.GetComponent<level_option_obj>();

                int num = i + 1;
                obj2.lvl_text.text = "Nivel " + num;

                obj2.lvl_qty1.text = game.nivel_req[i].ToString();
            }
        }
        
    }    


    public void add_editor()
    {
        for (int i = 0; i < origin.childCount; i++)
        {
            GameObject obj_c = origin.GetChild(i).gameObject;
            TMP_InputField input = obj_c.transform.GetChild(1).GetComponent<TMP_InputField>();

            editor.test.Add(input);
        }
    }

}
