using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class canvas_controller : MonoBehaviour
{
    public GameObject main_character;
    public Characters.Wizard main_hero;
    public Mage_control1 mage_;
    public Text level;
    public Text nicknaame_field;
    public Text condition_field;
    public Slider health_bar;
    public Slider mana_bar;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button[] buttons;
    public GameObject[] buttons_to_objects;
    public Button[] spells_buttons;
    public Spells.Spells[] spells;
    public Coroutine cor;
    public Sprite deafult;
    public int spell_points = 0;
    public Color changed_to_up;
    public bool is_upping=false;

    // Start is called before the first frame update
    void Start()
    {
        
        buttons_to_objects = new GameObject[5] { null, null, null, null, null };
        buttons = new Button[5] { button1, button2, button3, button4, button5 };
        main_character = GameObject.FindGameObjectWithTag("Player");
        main_hero = main_character.GetComponentInChildren<Characters.Wizard>();
        mage_ = main_character.GetComponentInChildren<Mage_control1>();
       
        spells_buttons[0].onClick.AddListener(mage_.fire_ball_cast_func);
        spells_buttons[1].onClick.AddListener(mage_.cast_heal);
        spells_buttons[2].onClick.AddListener(mage_.cast_cure);
        spells_buttons[3].onClick.AddListener(mage_.cast_antidote);
        spells_buttons[4].onClick.AddListener(mage_.cast_revive);
        spells_buttons[5].onClick.AddListener(mage_.cast_armor);
        nicknaame_field.text = main_character.GetComponent<Characters.Wizard>()._name+" : "+ main_character.GetComponent<Characters.Wizard>().CurrentRace.ToString();

        update_spells();


    }

    public void update_inventor_func()
    {
        
       
       for(int i=0;i<5;i++)
        {if (main_hero.inventory.container[i] != null)
            {
                add_art_to_button(buttons[i], main_hero.inventory.container[i]);
                
            }
            else
            {
             Button  buto= buttons[i];
                buto.onClick.RemoveAllListeners();
                buto.gameObject.GetComponent<Buttons_control>().pref = null;
                buto.gameObject.GetComponent<Image>().sprite = deafult;

            }
        }
            
            

        
    }


    public void add_art_to_button(Button but,Artefacts.Artefact art)
    {
        but.onClick.RemoveAllListeners();
        but.onClick.AddListener(delegate { main_hero.use_artefact_unity(art.id_); });
        Debug.Log(art.prefab);
        but.gameObject.GetComponent<Buttons_control>().pref = art.prefab;
        Debug.Log(but.gameObject.GetComponent<Buttons_control>().pref + " - префаб кнопки " );
        but.gameObject.GetComponent<Image>().sprite = art.icon;
        

    }

    public void throw_artefatc_unity(Button but)
    {
        Debug.Log("Выбрасываем");
       Artefacts.Artefact arti= but.GetComponent<Buttons_control>().pref.GetComponent<artefact_controller>().art;
        main_character.GetComponent<Characters.Wizard>().inventory.throw_item(arti);
        Vector3 local = main_character.transform.position;
        Instantiate(but.GetComponent<Buttons_control>().pref,new Vector3(local.x+5,local.y,local.z),new Quaternion());
        Destroy(but.GetComponent<Buttons_control>().pref);
      update_inventor_func();

    }
   
    public void cast_spell()
    {


    }

    public void update_bars()
    {
        health_bar.maxValue = main_character.GetComponent<Characters.Wizard>().MaxHp;
        health_bar.value = main_character.GetComponent<Characters.Wizard>().Hp;
        mana_bar.maxValue = main_character.GetComponent<Characters.Wizard>().max_Mana;
        mana_bar.value = main_character.GetComponent<Characters.Wizard>().Mana;
        level.text="Level: " + main_character.GetComponent<Characters.Wizard>().Level;
        condition_field.text ="Condition :"+ main_character.GetComponent<Characters.Wizard>().CurrentCondition.ToString();


    }

    public void disabel_tocast()
    {


    }

    public void start_upping()
    {
        Debug.Log("start_upping");
        cor = StartCoroutine(time_to_up_skill());
    }
    public  void update_spells()
    {
        is_upping = true;
        foreach (var item in spells_buttons)
        {
            if (!item.gameObject.GetComponent<spell_button_control>().is_learned)
            {
                var but = item.colors;

                but.normalColor = Color.black;
                item.colors = but;
               
                
            }
            else
            {
                var but = item.colors;

                but.normalColor = new Color(1,1,1,1);
                item.colors = but;

            }
        }
    }
   public IEnumerator time_to_up_skill()
    {
        Debug.Log("Начали раскрашивать");
        Color col = spells_buttons[0].colors.normalColor;
        for (int i = 0; i < 6; i++)
        {if(!spells_buttons[i].GetComponent<spell_button_control>().is_learned)
            {
                
                
                var but = spells_buttons[i].colors;
              
                but.normalColor = changed_to_up;
                spells_buttons[i].colors = but;
              
         
            }
        }
       
        Debug.Log("Начали ждать");
        while (spell_points >0)
        {
            


            yield return null;
        }
        Debug.Log("Закончили ждать");
        for (int i = 0; i < 6; i++)
        {
           
                var but = spells_buttons[i].colors;
                but.normalColor = col;
            spells_buttons[i].colors = but;

        }
        update_spells();
        is_upping = false; 

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
