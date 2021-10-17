using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_enemy : MonoBehaviour
{
    public GameObject main_body;
    public GameObject myobj;
    public Characters.Wizard target_class;
    public Characters.Enemy my_attaker;
    
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
        Debug.Log("Триггер сработал");

        GameObject target = other.gameObject;
        Rigidbody target_rg = target.GetComponent<Rigidbody>();


        my_attaker = main_body.GetComponent<Characters.Enemy>();
        target_class = target.GetComponent<Characters.Wizard>();



        if (target_class != null && target_class.Id != my_attaker.Id && (main_body.GetComponent<Characters.Enemy>().canDamage==true))
        {
            Debug.Log("Триггер Прошел проверку на совпадение и возможнотмть удара");
            BoxCollider box = GetComponent<BoxCollider>();
            main_body.GetComponent<Characters.Enemy>().canDamage = false;
            Debug.Log("возможность нанести урон выключен");
            my_attaker.ToHit(target_class);
            








        }
      





    }
}
