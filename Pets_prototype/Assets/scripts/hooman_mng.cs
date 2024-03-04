using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class hooman_mng : MonoBehaviour
{
    [Space(10)]
    [Header("Main Info")]
    public SO_HoomanInfo hooman_info;


    [Space(10)]
    [Header("Needs")]
    public List<int> need_int;

    [Space(10)]
    [Header("Managers")]
    private     Coin_mng coins_mng;
    private     Manager main_mng;
    private     need_mng needs_mng;
    private     levelup_mng level_mng;
    private     warning_mng warnings_mng;


    [Space(10)]
    [Header("UI Info")]
    private Main_ui ui_main;

    [Space(10)]
    [Header("Info extra")]
    private SO_Inst inst_actual;
    private SO_Need need_actual;       
    


    private void Awake()
    {       

        //Get mng
        coins_mng       = GameObject.FindGameObjectWithTag("Coin_mng").GetComponent<Coin_mng>();
        main_mng        = GameObject.FindGameObjectWithTag("Main_mng").GetComponent<Manager>();
        needs_mng       = GameObject.FindGameObjectWithTag("Need_mng").GetComponent<need_mng>();
        level_mng       = GameObject.FindGameObjectWithTag("Level_mng").GetComponent<levelup_mng>();
        warnings_mng    = GameObject.FindGameObjectWithTag("Warning_mng").GetComponent<warning_mng>();

        coins_mng.add_coins(0, main_mng.game_info.coins[0], main_mng.game_info);
        coins_mng.add_coins(1, main_mng.game_info.coins[1], main_mng.game_info);
        coins_mng.add_coins(2, main_mng.game_info.coins[2], main_mng.game_info);


        //Setup ui
        ui_main = main_mng.create_ui_obj(this.transform);

        stats_deactivate();
        main_mng.bounce_obj(ui_main.globe, Vector3.zero, 0.1f);

    }

    private void LateUpdate()
    {
        if(hooman_info)
        {
            ui_main.nom_text.text = hooman_info.nombre;
            ui_main.nivel_text.text = hooman_info.nivel.ToString();

            main_mng.stats_bars_set(hooman_info.stat_health, hooman_info.stat_happy, hooman_info.stat_energy, hooman_info.stat_social, ui_main.stats_bars);
        }        
    }

    public void stats_activate()
    {
        ui_main.stats_canvas.alpha = 1f;
    }

    public void stats_deactivate()
    {
        ui_main.stats_canvas.alpha = 0.1f;

    }

    public void check(SO_Inst inst, DragAndDropObject drag, hooman_mng hoo)
    {
        inst_actual = inst;
        main_mng.check(ui_main.bar_img, inst, this);

        main_mng.bounce_obj(ui_main.globe, new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
        ui_main.globe_text.text = inst.accion;

        //if (need_actual.id == inst.id)
        //{
        //}
        //else
        //{
        //    Debug.Log("otra necesidad");
        //}
    }

    public void stats_activate(Image image, float duration, float scale)
    {
        // Escala inicial (escala normal)
        image.transform.localScale = Vector3.one;

        // Hace crecer la imagen a la escala deseada
        image.transform.DOScale(Vector3.one * scale, duration)
            .SetEase(Ease.OutQuad) // Opcional: puedes ajustar la curva de animación aquí
            .OnComplete(() => // Cuando la animación completa
            {
                    // Vuelve a la escala normal
                    image.transform.DOScale(Vector3.one, duration)
                            .SetEase(Ease.OutQuad); // Opcional: puedes ajustar la curva de animación aquí
            });
    }

    IEnumerator stats_activate_corr()
    {
        for (int i = 0; i < ui_main.stats_bars.Count; i++)
        {
            stats_activate(ui_main.stats_bars[i], 0.3f, 1.2f);

            switch (i)
            {
                case 0:
                    main_mng.trigger_anima(inst_actual.stat_health, ui_main.stats_text, ui_main.stats_icon, ui_main.stats_anima, return_stat_sprite(i));
                    break;

                case 1:
                    main_mng.trigger_anima(inst_actual.stat_happy, ui_main.stats_text, ui_main.stats_icon, ui_main.stats_anima, return_stat_sprite(i));
                    break;

                case 2:
                    main_mng.trigger_anima(inst_actual.stat_energy, ui_main.stats_text, ui_main.stats_icon, ui_main.stats_anima, return_stat_sprite(i));
                    break;

                case 3:
                    main_mng.trigger_anima(inst_actual.stat_social, ui_main.stats_text, ui_main.stats_icon, ui_main.stats_anima, return_stat_sprite(i));
                    break;
            }


            yield return new WaitForSeconds(1f);
        }


        //float time_duration = Random.Range(time_duration_min, time_duration_max);
        Debug.Log("minus en " + 1f);

        yield return new WaitForSeconds(1f);
        check_stats_final();

    }

    public void needs_stats(SO_Inst inst)
    {
        hooman_info.stat_health = hooman_info.stat_health + inst.stat_health;
        hooman_info.stat_happy  = hooman_info.stat_happy + inst.stat_happy;
        hooman_info.stat_social = hooman_info.stat_social + inst.stat_social;
        hooman_info.stat_energy = hooman_info.stat_energy + inst.stat_energy;

        if (hooman_info.stat_health < 0) 
        {
            hooman_info.stat_health = 0;
        }
        else if (hooman_info.stat_health > 5)
        {
            hooman_info.stat_health = 5;
        }

        if (hooman_info.stat_happy < 0)
        {
            hooman_info.stat_happy = 0;
        }
        else if (hooman_info.stat_happy > 5)
        {
            hooman_info.stat_happy = 5;
        }

        if (hooman_info.stat_social < 0)
        {
            hooman_info.stat_social = 0;
        }
        else if (hooman_info.stat_social > 5)
        {
            hooman_info.stat_social = 5;
        }

        if (hooman_info.stat_energy < 0)
        {
            hooman_info.stat_energy = 0;
        }
        else if (hooman_info.stat_energy > 5)
        {
            hooman_info.stat_energy = 5;
        }


        stats_activate();

        level_up();
        StartCoroutine(stats_activate_corr());

    }

    public Sprite return_stat_sprite(int id)
    {
        Sprite sprite1 = main_mng.game_info.stats_icon_list[id];
        return sprite1;
    }
    
    public Sprite return_stat_sprite_white(int id)
    {
        Sprite sprite1 = main_mng.game_info.stats_icon_list_white[id];
        return sprite1;
    }

    public Color return_stat_color(int id)
    {
        Color color1 = main_mng.game_info.stats_color_list[id];
        return color1;
    }



    public void start_minus_stat()
    {
        StartCoroutine(minus_start());
    }

    IEnumerator minus_start()
    {
        float time_duration = Random.Range(hooman_info.time_duration_min, hooman_info.time_duration_max);
        yield return new WaitForSeconds(time_duration);

        int randomNumber = Mathf.FloorToInt(Random.Range(0f, 2f));

        if (randomNumber == 0)
        {
            minus_stat();
            Debug.Log("minus en " + time_duration);

        }
        else
        {
            Debug.Log("salvo");
        }


    }

    public void minus_stat()
    {
        int rand;

        if (hooman_info.nivel <2)
        {
            rand = Random.Range(0, 2);

        }
        else
        {
            rand = Random.Range(0, 3);
        }

        minus_stat_obj(rand);
    }

    public void minus_stat_obj(int num)
    {
        int rand_minus = Random.Range(0, 2);
        string reason = "";

        switch (rand_minus)
        {
            case 0:
                rand_minus = 1;
                break;

            case 1:
                rand_minus = 2;
                break;

            case 2:
                rand_minus = 3;
                break;
        }


        switch (num)
        {
            case 0:
                hooman_info.stat_health = hooman_info.stat_health - rand_minus;
                reason = main_mng.game_info.stats_reasons[0];
                break;

            case 1:
                hooman_info.stat_happy = hooman_info.stat_happy - rand_minus;
                reason = main_mng.game_info.stats_reasons[1];
                break;

            case 2:
                hooman_info.stat_energy = hooman_info.stat_energy - rand_minus;
                reason = main_mng.game_info.stats_reasons[2];
                break;

            case 3:
                hooman_info.stat_social = hooman_info.stat_social - rand_minus;
                reason = main_mng.game_info.stats_reasons[3];
                break;
        }

        main_mng.trigger_anima( - rand_minus, ui_main.stats_text, ui_main.stats_icon, ui_main.stats_anima, return_stat_sprite(num));
        needs_mng.setup(hooman_info.nombre, reason, num, rand_minus, return_stat_color(num), return_stat_sprite_white(num));
    }

    // condiciones de nuevas needs
    public void check_stats_final()
    {
        if (hooman_info.stat_health < 5 || hooman_info.stat_happy < 5 || hooman_info.stat_happy < 5)
        {
            need_int.Clear();

            if (hooman_info.stat_health < 5)
            {
                need_int.Add(0);
            }

            if (hooman_info.stat_happy < 5)
            {
                need_int.Add(1);
            }

            if (hooman_info.stat_energy < 5)
            {
                need_int.Add(2);
            }

            int rand_id;

            if (need_int.Count > 0)
            {
                rand_id = need_int[Random.Range(0, need_int.Count)];
            }
            else
            {
                rand_id = need_int[0];
            }

            for (int i = 0; i < hooman_info.need.Count; i++)
            {
                if (hooman_info.need[i].id == rand_id)
                {
                    Debug.Log("nueva need");
                    need_actual = hooman_info.need[i];

                    main_mng.bounce_obj(ui_main.globe, new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
                    ui_main.globe_text.text = need_actual.nombre;

                    break;
                }
            }

        }       

    }

    public void globe_off()
    {
        main_mng.bounce_obj(ui_main.globe, Vector3.zero, 0.2f);

    }


    public void level_up()
    {
        hooman_info.needs_cant++;
        coins_mng.add_coins(0, main_mng.game_info.coins_a, main_mng.game_info);

        if (main_mng.game_info.nivel_req[hooman_info.nivel] == hooman_info.needs_cant)
        {
            hooman_info.nivel++;
            level_mng.setup(this);
            coins_mng.add_coins(1, main_mng.game_info.coins_b, main_mng.game_info);

        }
    }

    public void send_warning(int id)
    {
        warnings_mng.setup(return_stat_color(id), main_mng.game_info.stats_warnings[id], return_stat_sprite(id));
    }


}
