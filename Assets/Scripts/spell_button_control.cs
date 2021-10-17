using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class spell_button_control : MonoBehaviour,IPointerClickHandler
{
    public Canvas main_inter;
    public bool is_learned=true;
    public Vector2 pos_start;
    public delegate void del();
    public del cast_func_;
    public event del func;
    // Start is called before the first frame update
    void Start()
    {
        pos_start = gameObject.transform.position;
        
    }
    
   void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Right)
        {
            Debug.Log("clicked right");
            if (main_inter.GetComponent<canvas_controller>().spell_points > 0)
            {
                Debug.Log("Проверка на поинты");
                if (!is_learned )
                {
                    Debug.Log("выучиваем");
                    is_learned = true;
                    
                    main_inter.GetComponent<canvas_controller>().spell_points--;
                }
                else
                {

                    click();
                }
            }
            else
            {
                if(is_learned)
                click();
            }

        }
       
    }

    public void click()
    {
       
            Debug.Log("click_detected");
            is_learned = false;
            main_inter.GetComponent<canvas_controller>().spell_points++;
            main_inter.GetComponent<canvas_controller>().start_upping();
        

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
