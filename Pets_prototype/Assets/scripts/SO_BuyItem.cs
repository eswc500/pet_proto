using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buy Item", menuName = "ScriptableObjects/New Buy Item")]
public class SO_BuyItem : ScriptableObject
{
    public int id;
    public string nombre;
    public int coin_type;
    public int precio;

}

