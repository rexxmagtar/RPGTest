using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_control__script : MonoBehaviour
{

    public   GameObject player_character;
    public GameObject[] choose_ = new GameObject[4];
    public string nickname;
    public InputField input_field;
    public Sprite empty;
    public Sprite loading;
    public Image load;
    // Start is called before the first frame update
    void Start()
    {
      
           
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void choose_race(int i)
    {
      
        player_character = choose_[i];

        my_static_script.gamecontroller = gameObject;
        Application.LoadLevel("name_choose");
        
        
    }
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    public void check_pattern(string s)
    {
        if(s=="")
        {

        }
    }

    public void confirm()
    {
        nickname = input_field.text;
        my_static_script.gamecontroller.GetComponent<Game_control__script>().player_character.GetComponentInChildren<Characters.Wizard>()._name = nickname;
        load.sprite = loading;
        load.gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width/2, Screen.height/2);
        SceneManager.LoadSceneAsync("level_1");
        SceneManager.UnloadScene("name_choose");

  

    }
}
