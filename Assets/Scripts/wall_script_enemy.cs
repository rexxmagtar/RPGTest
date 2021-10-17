using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_script_enemy : MonoBehaviour
{
    public Vector2 derect;
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

        AI_control move_func = other.gameObject.GetComponent<linkto3d>().main_3d.GetComponent<AI_control>();

        if (move_func != null)
        {

            if (move_func.enemy_direction == derect || move_func.enemy_direction == Vector2.zero)
            {
                //Debug.Log("Velocity_changed");
                move_func.velocity = 0;
            }
            else
            {
                //Debug.Log("Velocity_changed");
                move_func.velocity = move_func.stable_velocity;

            }
        }






    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        AI_control move_func = other.gameObject.GetComponent<linkto3d>().main_3d.GetComponent<AI_control>();
        if (move_func != null)
        {
            derect = move_func.enemy_direction;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
