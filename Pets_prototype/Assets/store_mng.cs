using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_mng : MonoBehaviour
{
    public List<SO_BuyItem> buy_list;
    public List<buy_item>   buy_obj_list;
    public buy_item buy_actual;

    public GameObject ui_origin;
    public GameObject ui_prefab;
    public GameObject store_open;

    //activa tienda
    public void open_store_obj()
    {
        store_open.SetActive(true);
    }

    public void close_store_obj()
    {
        store_open.SetActive(false);
    }

    // poblar data
    public void setup_data()
    {
        if(ui_origin.transform.childCount == 0)
        {
            buy_obj_list = new List<buy_item>();

            for (int i = 0; i < buy_list.Count; i++)
            {
                GameObject buyobj = Instantiate(ui_prefab, ui_origin.transform);
                buy_item buytobj_item = buyobj.GetComponent<buy_item>();
                buytobj_item.setup(buy_list[i]);
                buytobj_item.unselect();

                buy_obj_list.Add(buytobj_item);
            }
        }
    }

    //buy
    public void select_data(buy_item item)
    {
        buy_actual = item;
        for (int i = 0; i < buy_obj_list.Count; i++)
        {
            if(buy_obj_list[i]!=item)
            {
                buy_obj_list[i].unselect();

            }
            else
            {
                buy_obj_list[i].select();

            }
        }
    }




}
