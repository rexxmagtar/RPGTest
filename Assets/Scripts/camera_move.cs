using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    void Start()
    {
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player!=null)
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2,-60);
    }
}
