using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class do_not_rotate : MonoBehaviour
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
        if (main_hero.GetComponent<Player_move>().direct_ == Vector2.right)
            transform.localScale = new Vector3(1, 1, 1);
        if(main_hero.GetComponent<Player_move>().direct_ == Vector2.left)
            transform.localScale = new Vector3(-1, 1, 1);

    }
}
