using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropObject : MonoBehaviour
{
    public bool isDragging;
    public hooman_mng hooman;

    public void OnMouseDown()
    {
        isDragging = true;
        hooman.stats_activate();
    }

    private void OnMouseExit()
    {
        //hooman.stats_deactivate();
    }

    public void OnMouseUp()
    {
        isDragging = false;
        hooman.stats_deactivate();

    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");

        hooman_mng hooman;
        hooman = this.GetComponent<hooman_mng>();


        drop_zone mng = collision.gameObject.GetComponent<drop_zone>();

        if (mng )
        {
            // Tiene energia
            if (mng.inst.stat_energy == 5)
            {
                hooman.check(mng.inst, this, hooman);

            }
            else 
            {
                if (hooman.hooman_info.stat_energy > 0 && hooman.hooman_info.stat_energy >= mng.inst.stat_energy)
                {

                    hooman.check(mng.inst, this, hooman);

                }
                else if(hooman.hooman_info.stat_energy <= 0)
                {
                    hooman.send_warning(2);
                }
            }



            
        }

    }

}
