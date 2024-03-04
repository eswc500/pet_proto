using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hooman Info", menuName = "ScriptableObjects/Hooman Info")]
public class SO_HoomanInfo : ScriptableObject
{
    public string nombre;
    public int nivel;
    public int needs_cant;

    [Space(10)]
    [Header("Stats")]
    public int stat_health = 5;
    public int stat_happy = 5;
    public int stat_energy = 5;
    public int stat_social = 5;

    [Space(30)]
    [Header("Tiempo")]
    public float time_duration_min;
    public float time_duration_max;     


    [Space(30)]
    [Header("Needs")]
    public List<SO_Need> need;

}
