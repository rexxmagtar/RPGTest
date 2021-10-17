using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Buttons_control : MonoBehaviour,  IDragHandler, IEndDragHandler
{
    public Canvas main_canvas;
        public Vector3 start_pos;
    public GameObject pref;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Image>().sprite != main_canvas.GetComponent<canvas_controller>().deafult)
        {
            Debug.Log("Держится");
            if (Input.GetMouseButton(1))
            {
                Vector3 mouse_pos = Input.mousePosition;
                gameObject.transform.position = mouse_pos;
            }
        }

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.position = start_pos;

       
            Debug.Log("Начинаем выполнеие");
           
            if (gameObject.GetComponent<Image>().sprite != main_canvas.GetComponent<canvas_controller>().deafult)
                main_canvas.GetComponent<canvas_controller>().throw_artefatc_unity(gameObject.GetComponent<Button>());
        
    }

   

}
