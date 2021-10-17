using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_script : MonoBehaviour
{
    public Vector2 derect;
    Player_move move_func;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Проверяем stay");
        move_func = other.gameObject.GetComponent<linkto3d>().main_3d.GetComponent<Player_move>();
       
        if (move_func != null )
        {if(move_func.direction!=Vector2.zero)
            Debug.Log("Пробуем пойти в направлении " + move_func.direction);

            if (move_func.direction == derect ||move_func.direction==Vector2.zero)
            {
                Debug.Log(move_func.direction + "не получилось");
                move_func.velocity = 0;
            }
            else
            {
                Debug.Log("Velocity_changed to normal");
                move_func.velocity = move_func.velocity_base;

            }
        }




        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        move_func = other.gameObject.GetComponent<linkto3d>().main_3d.GetComponent<Player_move>();
        if (move_func != null)
        {
            derect = move_func.direction;
            Debug.Log(other + " entered" + gameObject);
            Debug.Log("Запрещенное направление is " + derect);
        }

    }
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    Debug.Log("столкновение покинуто");
    //    //Player_move move_func = other.gameObject.GetComponent<linkto3d>().main_3d.GetComponent<Player_move>();
    //    //if (move_func != null)
    //    //{
    //    //     move_func.velocity=move_func.velocity_base;
    //    //}
    //}
    





}
