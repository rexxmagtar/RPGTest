using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class do_not_rotate_enenmy : MonoBehaviour
{
    private Transform starting_transform;
    public GameObject main_hero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (main_hero.GetComponent<AI_control>().enemy_direction.x>=0)
            transform.localScale = new Vector3(1, 1, 1);
        if (main_hero.GetComponent<AI_control>().enemy_direction.x<0)
            transform.localScale = new Vector3(-1, 1, 1);

    }
}
