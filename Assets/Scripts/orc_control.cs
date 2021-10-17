using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orc_control : MonoBehaviour
{

    
    public Animation anim;
    public BoxCollider box_wearpon;
    public Transform direction;
    

    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        if (anim.isPlaying == false)
        {
            box_wearpon.isTrigger = false;
            GetComponent<BoxCollider>().size = new Vector3(3, 3, 3);

        }
        if (Input.GetKey(KeyCode.Q))
        {
          
            box_wearpon.isTrigger = true;
            anim.Play("Killing");
            




            ///реализуем атаку в общем апдейте

        }
        if (Input.GetKey(KeyCode.Z))
        {

            anim.Play("special attack");
        }
    }

    public void hit_func()
    {

    }/// <summary>
    /// НАодо обратиться  к топору
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
