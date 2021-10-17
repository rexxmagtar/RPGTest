using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_trigger_wearpon : MonoBehaviour
{
    public GameObject main_body;
    public  GameObject myobj;
    public Characters.Warrior target_class;
    public Characters.Warrior my_attaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        
        
        GameObject target = other.gameObject;
        Rigidbody target_rg = target.GetComponent<Rigidbody>();


        my_attaker = main_body.GetComponent<Characters.Warrior>();
        target_class = target.GetComponent<Characters.Warrior>();


        
        if (target_class != null && target_class.Id != my_attaker.Id)
        {
            BoxCollider box = GetComponent<BoxCollider>();
            box.isTrigger = false;
            my_attaker.ToHit(target_class);
            BoxCollider main_box = main_body.GetComponent<BoxCollider>();
            
            






        }
        
       



    }
}
