using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Manager : MonoBehaviour
{
    [Space(10)]
    [Header("Info Stats")]
    public SO_GameInfo game_info;

    [Space(30)]
    [Header("Prefab UI")]
    public Transform ui_origin;
    public GameObject ui_obj;

    [Space(30)]
    [Header("Hoomans")]
    public Transform hooman_origin;
    public GameObject hooman_obj;
    public List<SO_HoomanInfo> hooman_list;

    [Space(30)]
    [Header("Coin")]
    public Sprite coin_a_sprite;
    public Sprite coin_b_sprite;

    public Sprite return_coin_sprite(int id)
    {
        if(id == 0)
        {
            return coin_a_sprite;
        }
        else
        {
            return coin_b_sprite;
        }
    }



    private void Awake()
    {
        //coins
        game_info.coins[0] = 0;
        game_info.coins[1] = 0;
        game_info.coins[2] = 0;

        StartCoroutine(create_hoomans_timer());
    }

    IEnumerator create_hoomans_timer()
    {
        for (int i = 0; i < 3; i++)
        {
            create_hooman();
            yield return new WaitForSeconds(2);
        }
    }

    public void create_hooman()
    {
        GameObject hooman = Instantiate(hooman_obj, hooman_origin);
        // Crear y Asignar Scriptable
        SO_HoomanInfo new_hooman = ScriptableObject.CreateInstance<SO_HoomanInfo>();

        int id = hooman_list.Count + 1;
        new_hooman.nombre = "Loonchie " + id.ToString();
        new_hooman.time_duration_min = game_info.time_duration_min;
        new_hooman.time_duration_max = game_info.time_duration_max;

        new_hooman.stat_health = 5;
        new_hooman.stat_happy = 5;
        new_hooman.stat_energy = 5;
        new_hooman.stat_social = 5;

        new_hooman.need = new List<SO_Need>();

        for (int i = 0; i < game_info.need.Count; i++)
        {
            new_hooman.need.Add(game_info.need[i]);
        }

        hooman_mng mng_hooman = hooman.GetComponent<hooman_mng>();
        mng_hooman.hooman_info = new_hooman;


        //Color
        SpriteRenderer sprite_hooman = hooman.GetComponent<SpriteRenderer>();
        Color random_col = new Color(Random.value, Random.value, Random.value);
        sprite_hooman.color = random_col;

        //Lista de hoomans
        hooman_list.Add(new_hooman);

    }


    public Main_ui create_ui_obj(Transform obj_trans)
    {
        GameObject ui_obj_create = Instantiate(ui_obj, ui_origin);
        
        Follow_hooman follow;
        follow = ui_obj_create.GetComponent<Follow_hooman>();
        follow.target = obj_trans;

        Main_ui ui_main;        
        ui_main = ui_obj_create.GetComponent<Main_ui>();
        return ui_main;
    }


    public void stats_bars_set(int health, int happy, int energy, int social, List<Image> stats_bars)
    {
        stats_bars[0].fillAmount = (float)health / 10 ;
        stats_bars[1].fillAmount = (float)happy / 10 ;
        stats_bars[2].fillAmount = (float)energy / 10 ;
        stats_bars[3].fillAmount = (float)social / 10 ;
    }

    public void trigger_anima(int qty, TextMeshProUGUI stats_text, Image stats_icon, Animator stats_anima, Sprite stats_sprite)
    {
        if(qty != 0)
        {
            if (qty > 0)
            {
                stats_text.text = "+" + qty.ToString();

            }
            else
            {
                stats_text.text = qty.ToString();

            }
            stats_icon.sprite = stats_sprite;
            stats_anima.SetTrigger("go");
        }
        else
        {
            Debug.Log("equal 0");
        }        
    }


    public void check(Image ui, SO_Inst inst_obj, hooman_mng hoo)
    {
        float time_final = inst_obj.duracion;
        // No esta happy?
        if (hoo.hooman_info.stat_happy == 0)
        {
            hoo.send_warning(1);
            time_final = inst_obj.duracion * 2;
        }        

        if (ui.fillAmount != 0)
        {
            if (ui != null && ui.fillAmount > 0)
            {
                ui.gameObject.transform.parent.gameObject.SetActive(true);
                               
                ui.DOFillAmount(0f, time_final).OnComplete(() =>
                {
                    Debug.Log("Fill Amount ha llegado a 0.");

                    hoo.needs_stats(inst_obj);
                    hoo.start_minus_stat();
                    hoo.globe_off();
                });
            }
            else
            {
                Debug.LogWarning("La imagen es nula o Fill Amount ya es 0.");

                ui.gameObject.transform.parent.gameObject.SetActive(false);

            }
        }
        else
        {
            ui.fillAmount = 1;

            ui.DOFillAmount(0f, time_final).OnComplete(() =>
            {
                Debug.Log("Fill Amount ha llegado a 0.");

                hoo.needs_stats(inst_obj);
                hoo.start_minus_stat();
            });
        }        
    }


    public void bounce_obj(RectTransform rect, Vector3 targetScale, float duration)
    {
        Vector3 originalScale = rect.transform.localScale;

        rect.transform.DOKill();
        rect.transform.DOScale(targetScale, duration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                rect.transform.DOScale(originalScale, duration)
                    .SetEase(Ease.InQuad);
            });


    }

}
