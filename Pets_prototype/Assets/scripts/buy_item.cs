using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buy_item : MonoBehaviour
{
    public SO_BuyItem       buy_object;

    public GameObject       select_object;
    public TextMeshProUGUI  buy_nom;
    public Image            buy_coin;
    public TextMeshProUGUI  buy_price;

    [Space(10)]
    [Header("Managers")]
    private Manager main_mng;
    private store_mng store_mng;

    private void Awake()
    {
        store_mng   =   GameObject.FindGameObjectWithTag("Store_mng").GetComponent<store_mng>();
        main_mng    =   GameObject.FindGameObjectWithTag("Main_mng").GetComponent<Manager>();
    }

    public void setup(SO_BuyItem buy_item_obj)
    {
        buy_object = buy_item_obj;

        buy_nom.text = buy_object.nombre;
        buy_price.text = buy_object.precio.ToString();
        buy_coin.sprite = main_mng.return_coin_sprite(buy_object.coin_type);

        unselect();
    }

    public void select()
    {
        select_object.SetActive(true);
    }

    public void unselect()
    {
        select_object.SetActive(false);

    }

    public void select_item()
    {
        if(store_mng)
        {
            store_mng.select_data(this);
        }
    }



}

