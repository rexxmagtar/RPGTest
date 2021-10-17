using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mage_control1 : MonoBehaviour
{
    public GameObject fire_ball_;
    public GameObject heal;
    public GameObject cure_spell;
    public GameObject antidote;
    public GameObject revive;
    public GameObject armor;
    public bool Fire_ball_is_able_to_cast=true;
    public float fire_ball_cooldown=0.3f;
    public Coroutine cor;
    public AudioSource audio_;
    public TextMeshProUGUI message;
    public Vector2 mouse_point;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))/// огненный шар
        {
            fire_ball_cast_func();
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            cast_heal();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            cast_cure();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            cast_antidote();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {

            cast_revive();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {

            cast_armor();
        }

    }


    public void create_message( string text)
    {
        gameObject.AddComponent<TextMeshPro>();

    }

   

    public IEnumerator disapera_message(string text)
    {

        Color k = message.color;

        
        k.a = 1f;
        message.color = k;
        message.text = text;
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = message.color;
            if (c.a == 0f)
                break;
            c.a = f;
            message.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator fire_cooldown(float sec)
    {
        Debug.Log("cool_started");  
        yield return new WaitForSeconds(sec);
        
        Fire_ball_is_able_to_cast = true;
        

    }
    public void fire_throw()
    {
        audio_.clip = Resources.Load("fire_sound") as AudioClip;
        audio_.Play();
        gameObject.GetComponent<Characters.Wizard>().Mana -= new Spells.FireBall().ManaCost;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("Killing_mage");
        fire_blast_control fr = fire_ball_.GetComponent<fire_blast_control>();
        fr.atacker = gameObject;
        Vector3 pos_ = gameObject.transform.position;
        Instantiate(fire_ball_, new Vector3(pos_.x, pos_.y + 2, pos_.z), new Quaternion(0, 0, 0, 0));

    }


    public void fire_ball_cast_func()
    {
        if(gameObject.GetComponent<Characters.Wizard>().menu.GetComponent<canvas_controller>().spells_buttons[0].GetComponent<spell_button_control>().is_learned==false)
        {
            Debug.Log("не изучено");
                return;
        }

        mouse_point = Input.mousePosition;
        if (Fire_ball_is_able_to_cast && gameObject.GetComponent<Characters.Wizard>().Mana >= new Spells.FireBall().ManaCost)
        {
            Fire_ball_is_able_to_cast = false;
            fire_throw();
            Coroutine corut = StartCoroutine(fire_cooldown(fire_ball_cooldown));

        }
        else
        {

            Color c = message.color;

            c.a = 0f;
            message.color = c;


            if (!Fire_ball_is_able_to_cast)
            {
                audio_.clip = Resources.Load("reload_sound_voice") as AudioClip;
                audio_.Play();
                Coroutine cor1;
                cor1 = StartCoroutine(disapera_message("reload"));
                Debug.Log("cool_down");
            }
            else
            {
                Coroutine cor1;


                cor1 = StartCoroutine(disapera_message("no mana"));
            }
        }
    }

    public void cast_heal()
    {
        if (gameObject.GetComponent<Characters.Wizard>().menu.GetComponent<canvas_controller>().spells_buttons[1].GetComponent<spell_button_control>().is_learned == false)
        {
            disapera_message("не изучено");
            return;
        }
        gameObject.GetComponent<Characters.Wizard>().UseHealingSpell();
        Instantiate(heal, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void cast_cure()
    {
        if (gameObject.GetComponent<Characters.Wizard>().menu.GetComponent<canvas_controller>().spells_buttons[2].GetComponent<spell_button_control>().is_learned == false)
        {
            disapera_message("не изучено");
            return;
        }
        gameObject.GetComponent<Characters.Wizard>().UseCureSpell();
        Instantiate(cure_spell, gameObject.transform.position, gameObject.transform.rotation);

    }

    public void cast_antidote()
    {
        if (gameObject.GetComponent<Characters.Wizard>().menu.GetComponent<canvas_controller>().spells_buttons[3].GetComponent<spell_button_control>().is_learned == false)
        {
            disapera_message("не изучено");
            return;
        }
        gameObject.GetComponent<Characters.Wizard>().UseAntidoteSpell();
        Instantiate(antidote, gameObject.transform.position, gameObject.transform.rotation);

    }

    public void cast_revive()
    {
        if (gameObject.GetComponent<Characters.Wizard>().menu.GetComponent<canvas_controller>().spells_buttons[4].GetComponent<spell_button_control>().is_learned == false)
        {
            disapera_message("не изучено");
            return;
        }
        gameObject.GetComponent<Characters.Wizard>().UseReviveSpell();
        Instantiate(revive, gameObject.transform.position, gameObject.transform.rotation);

    }


    public void cast_armor()
    {
        if (gameObject.GetComponent<Characters.Wizard>().menu.GetComponent<canvas_controller>().spells_buttons[5].GetComponent<spell_button_control>().is_learned == false)
        {
            disapera_message("не изучено");
            return;
        }
        cor = StartCoroutine(casting(10, gameObject.GetComponent<Characters.Wizard>()));
        gameObject.GetComponent<Characters.Wizard>().UseArmorSpell();
        Instantiate(armor, gameObject.transform.position, gameObject.transform.rotation);


    }
    public IEnumerator casting( float secs,Characters.Wizard revivedCharacter)
    {

        Debug.Log("Вы бессмертны");
        int hp_start = revivedCharacter.Hp;
        int max_hp = revivedCharacter.MaxHp;

        revivedCharacter.MaxHp = 999999999;
        revivedCharacter.Hp = 999999;

        yield return new WaitForSeconds(secs);
        Debug.Log("Вы снова обычный человек");
        revivedCharacter.MaxHp = max_hp;
        revivedCharacter.Hp = hp_start;

    }

}


