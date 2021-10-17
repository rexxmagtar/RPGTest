using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agro_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject main_body;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Characters.Wizard>() != null)
        {
            Debug.Log("Обнаружен герой!");
        }
    }



    public void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.GetComponent<Characters.Wizard>() != null)
        {
            main_body.GetComponent<Characters.Enemy>().state = Characters.Character.current_state.is_fighting;
            main_body.GetComponent<AI_control>().try_to_kill(other.gameObject);

        }

        
    }
}
