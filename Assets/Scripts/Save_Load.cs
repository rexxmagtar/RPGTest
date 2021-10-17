using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;


public class Save_Load : MonoBehaviour
{
    private  GameObject character_load;
    public GameObject Character_main;
    public GameObject player;
    public Transform[] obj_mass;
    public GameObject[] obj_save_mass;
   public  bool flag = false;
    
    public BinaryFormatter seria = new BinaryFormatter();
    // Update is called once per frame
    private void Start()
    {
        
        if (PlayerPrefs.GetInt("lvl") == Application.loadedLevel)
            load();

    }
    void Update()
    {
        

        if (Input.GetKey(KeyCode.M))
            save();
        
       
        if (Input.GetKeyDown(KeyCode.L))
        {
           
            Application.LoadLevel(PlayerPrefs.GetInt("lvl"));
           
        }



    }


    public void load_level()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("lvl"));
    }

    public void save()
    {
        obj_save_mass = FindObjectsOfType<GameObject>();

        player = GameObject.FindGameObjectWithTag("Player");

       

        PlayerPrefs.SetInt("lvl", Application.loadedLevel);

        player.GetComponent<Characters.Wizard>().char_pos =new Vector3( player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Characters.Wizard_save_data saved_class = new Characters.Wizard_save_data(player.GetComponent<Characters.Wizard>());
        using (FileStream fs=new FileStream("Main_character0", FileMode.OpenOrCreate))
        {
            seria.Serialize(fs,saved_class);

        }
            
        


    }

    public void load()
    {
        Debug.Log("load_start");
        Debug.Log("New_scene started");
       
        Characters.Wizard_save_data saved;
        using (FileStream fs = new FileStream("Main_character0", FileMode.Open))
        {

            saved = (Characters.Wizard_save_data)seria.Deserialize(fs);
        }
        Characters.Wizard load;
      
        
        Character_main.GetComponent<Characters.Wizard>().Wizard_get_save(saved);
        load = Character_main.GetComponent<Characters.Wizard>();




        Debug.Log("load_pos_change");
        
         Instantiate(Character_main,load.char_pos,new Quaternion());
     
     

    }
}
