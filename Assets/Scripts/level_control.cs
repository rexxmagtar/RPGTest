using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            Characters.Wizard our_wizard = my_static_script.gamecontroller.GetComponent<Game_control__script>().player_character.GetComponentInChildren<Characters.Wizard>();
            our_wizard.menu = GameObject.FindGameObjectWithTag("menu").GetComponent<Canvas>();
            Instantiate(my_static_script.gamecontroller.GetComponent<Game_control__script>().player_character, new Vector3(10, 0, -3), new Quaternion());

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
