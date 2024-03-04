using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Info", menuName = "ScriptableObjects/Game Info")]
public class SO_GameInfo : ScriptableObject
{
    public List<Sprite> stats_icon_list;
    public List<Sprite> stats_icon_list_white;
    public List<Color> stats_color_list;
    public List<string> stats_reasons;
    public List<string> stats_warnings;

    [Space(30)]
    [Header("Tiempo")]
    public float time_duration_min;
    public float time_duration_max;

    [Space(30)]
    [Header("Coins")]
    public int coins_a;
    public int coins_b;

    [Space(30)]
    [Header("Levels")]
    public List<int> nivel_req;

    [Space(30)]
    [Header("Coin")]
    public List<int> coins;

    [Space(30)]
    [Header("Needs")]
    public List<SO_Need> need;

}
