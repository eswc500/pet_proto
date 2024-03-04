using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class editor_mng : MonoBehaviour
{
    public SO_HoomanInfo page1;
    public SO_GameInfo page2;
    public List<SO_Need> need_page;
    public List<SO_Inst> inst_page;

    int indice;
    int indice_needs;
    public List<string> indice_text;

    public int min;
    public int max;

    public TextMeshProUGUI titulo;
    public List<GameObject> obj_page;
    public editor_page hooman_pages;
    public level_options level_pages; 
    public editor_page need_pages;
    public editor_page lvl_pages;
    public editor_page coins_pages;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject all_panel;
    public Button but_save;

    public string escena;
    private void Start()
    {
        get_max();
        titulo.text = indice_text[indice];
        set_page();
    }

    public void get_max()
    {
        int num = 2;
        num = num + need_page.Count;

        max = num;

        indice_text.Add("hooman info");
        indice_text.Add("niveles info");
        for (int i = 0; i < need_page.Count; i++)
        {
            int num_ind = i + 1;
            indice_text.Add("need #"+ num_ind);

        }
        indice_text.Add("coins info");

    }

    public void plus_indice(bool check)
    {
        if(check is true)
        {            
            indice++;
        }
        else
        {
            indice--;
        }

        if(indice > max)
        {
            indice = max;
        }
        if(indice < 0)
        {
            indice = 0;
        }

        titulo.text = indice_text[indice];
        set_page();
    }


    public void set_page()
    {
        if(indice == 0)
        {
            page1_hooman();
            obj1.SetActive(false);

        }

        if (indice == 1)
        {
            page2_nivelreq();

            obj1.SetActive(true);
            obj2.SetActive(true);

            if(lvl_pages.test.Count == 0)
            {
                level_pages.add_editor();
            }
        }

        if (indice >=2 && indice != max)
        {
            page3_need();

            obj1.SetActive(true);
            obj2.SetActive(true);
        }

        if(indice == max)
        {
            page4_coin();

            obj2.SetActive(false);

        }

        StartCoroutine(block_but(but_save));

    }

    public void page1_hooman()
    {
        for (int i = 0; i < obj_page.Count; i++)
        {
            if(i==0)
            {
                obj_page[i].SetActive(true);
            }
            else
            {
                obj_page[i].SetActive(false);
            }
        }

        hooman_pages.get_text(page1.nombre, hooman_pages.test[0]);
        hooman_pages.get_text(page1.stat_health.ToString(), hooman_pages.test[1]);
        hooman_pages.get_text(page1.stat_happy.ToString(), hooman_pages.test[2]);
        hooman_pages.get_text(page1.stat_energy.ToString(), hooman_pages.test[3]);
        hooman_pages.get_text(page1.stat_social.ToString(), hooman_pages.test[4]);
        hooman_pages.get_text(page1.time_duration_min.ToString(), hooman_pages.test[5]);
        hooman_pages.get_text(page1.time_duration_max.ToString(), hooman_pages.test[6]);

    }
    
    public void page2_nivelreq()
    {
        for (int i = 0; i < obj_page.Count; i++)
        {
            if (i == 1)
            {
                obj_page[i].SetActive(true);
            }
            else
            {
                obj_page[i].SetActive(false);
            }
        }
        level_pages.setup(page2);
    }

    public void page3_need()
    {
        for (int i = 0; i < obj_page.Count; i++)
        {
            if (i == 2)
            {
                obj_page[i].SetActive(true);
            }
            else
            {
                obj_page[i].SetActive(false);
            }
        }

        int indice_f = indice - 2;

        need_pages.get_text(need_page[indice_f].nombre, need_pages.test[0]);
        need_pages.get_text(inst_page[indice_f].nombre, need_pages.test[1]);
        need_pages.get_text(inst_page[indice_f].accion, need_pages.test[2]);
        need_pages.get_text(inst_page[indice_f].stat_health.ToString(), need_pages.test[3]);
        need_pages.get_text(inst_page[indice_f].stat_happy.ToString(), need_pages.test[4]);
        need_pages.get_text(inst_page[indice_f].stat_energy.ToString(), need_pages.test[5]);
        need_pages.get_text(inst_page[indice_f].stat_social.ToString(), need_pages.test[6]);
        need_pages.get_text(inst_page[indice_f].duracion.ToString(), need_pages.test[7]);

    }

    public void page4_coin()
    {
        for (int i = 0; i < obj_page.Count; i++)
        {
            if (i == 3)
            {
                obj_page[i].SetActive(true);
            }
            else
            {
                obj_page[i].SetActive(false);
            }
        }
        coins_pages.get_text(page2.coins_a.ToString(), coins_pages.test[0]);
        coins_pages.get_text(page2.coins_b.ToString(), coins_pages.test[1]);

    }

    public void save_hooman()
    {
        page1.nombre = hooman_pages.test[0].text;

        page1.stat_health = return_num(hooman_pages.test[1].text);
        page1.stat_happy = return_num(hooman_pages.test[2].text);
        page1.stat_energy = return_num(hooman_pages.test[3].text);
        page1.stat_social = return_num(hooman_pages.test[4].text);

        page1.time_duration_min = return_num(hooman_pages.test[5].text);
        page1.time_duration_max = return_num(hooman_pages.test[6].text);
    }

    public void save_level()
    {
        for (int i = 0; i < lvl_pages.test.Count; i++)
        {
            page2.nivel_req[i] = return_num(lvl_pages.test[i].text);
        }
    }

    public void save_need()
    {
        int indice_f = indice - 2;

        need_page[indice_f].nombre = need_pages.test[0].text;
        inst_page[indice_f].nombre = need_pages.test[1].text;
        inst_page[indice_f].accion = need_pages.test[2].text;

        inst_page[indice_f].stat_health = return_num(need_pages.test[3].text);
        inst_page[indice_f].stat_happy = return_num(need_pages.test[4].text);
        inst_page[indice_f].stat_energy = return_num(need_pages.test[5].text);
        inst_page[indice_f].stat_social = return_num(need_pages.test[6].text);

        inst_page[indice_f].duracion = return_num(need_pages.test[7].text);
    }

    public void save_coin()
    {
        page2.coins_a = return_num(coins_pages.test[0].text);
        page2.coins_b = return_num(coins_pages.test[1].text);
    }

    public void save_button()
    {
        if (indice == 0)
        {
            save_hooman();
        }

        if (indice == 1)
        {
            save_level();
        }

        if (indice >= 2 && indice != max)
        {
            save_need();
        }

        if (indice == max)
        {
            save_coin();
        }

        StartCoroutine(block_but(but_save));
    }

    IEnumerator block_but(Button but)
    {
        but.interactable = false;
        yield return new WaitForSeconds(2f);
        but.interactable = true;

    }

    public void restart()
    {
        SceneManager.LoadScene(escena);
    }

    public void open_panel(bool check)
    {
        if(check is true)
        {
            all_panel.SetActive(true);
        }
        else
        {
            all_panel.SetActive(false);
        }
    }

    public int return_num(string texto)
    {
        int num = 0;

        if (int.TryParse(texto, out int numeroEntero))
        {
            num = numeroEntero;
        }
        
        return num;
    }



}
