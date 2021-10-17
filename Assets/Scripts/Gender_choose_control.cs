using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gender_choose_control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject brother;
    public Characters.Character.Gender gender;
    public Sprite defaul;
    public Sprite cheked;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public void chenge_gender(Toggle toggle)
    {



        if (gameObject.GetComponent<Toggle>().isOn)
        {
            my_static_script.gamecontroller.GetComponent<Game_control__script>().player_character.GetComponentInChildren<Characters.Wizard>().CurrentGender = gender;
            toggle.isOn = false;
        }

    }
}
