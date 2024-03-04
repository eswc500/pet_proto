using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main_ui : MonoBehaviour
{
    [Space(30)]
    [Header("UI")]
    public TextMeshProUGUI nom_text;
    public TextMeshProUGUI nivel_text;
    public List<Image> stats_bars;
    public CanvasGroup stats_canvas;
    public Animator stats_anima;
    public TextMeshProUGUI stats_text;
    public Image stats_icon;
    public RectTransform globe;
    public TextMeshProUGUI globe_text;
    public Image bar_img;

}
