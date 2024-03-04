using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Instalation", menuName = "ScriptableObjects/New Inst")]
public class SO_Inst : ScriptableObject
{
    public int id;
    public string nombre;
    public string accion;

    [Space(10)]
    [Header("Stats")]
    public int stat_health;
    public int stat_happy;
    public int stat_social;
    public int stat_energy;

    [Space(10)]
    [Header("Duracion")]
    public float duracion;

}
