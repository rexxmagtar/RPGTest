using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_control : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity;
    public float stable_velocity;
    public GameObject wearpon;
    public Coroutine cor;
    public Vector2 enemy_direction = Vector2.right;
    public Vector2 direction_agro;
    public AudioSource music;
    public float attak_cooldown;
    public bool is_able_to_attack;
    void Start()
    {
        velocity = gameObject.GetComponent<Characters.Enemy>().speed;
        stable_velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.P))
            walk(Vector2.right);
        if (Input.GetKey(KeyCode.O))
            walk(Vector2.left);
        if (Input.GetKey(KeyCode.U))
            walk(Vector2.up);
        if (Input.GetKey(KeyCode.J))
            walk(Vector2.down);

        if (Input.GetKeyDown(KeyCode.I))
            attack();
        if(GetComponent<Characters.Enemy>().state==Characters.Character.current_state.got_damage)
        {
            try_to_kill(GameObject.FindGameObjectWithTag("Player"));
        }
    }


    public void walk(Vector2 direc)
    {
        enemy_direction =new Vector2( Mathf.Ceil( Mathf.Abs(direc.x))*Mathf.Sign(direc.x), Mathf.Ceil(Mathf.Abs(direc.y)) * Mathf.Sign(direc.y));
        if (direc.x >= 0)
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        else
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        if (velocity!=0)
            gameObject.GetComponent<Animation>().Play("Walking");

        gameObject.transform.parent.transform.Translate(direc*Time.deltaTime);
    }

  

    public void attack()
    {
        Debug.Log(is_able_to_attack);
        if (is_able_to_attack==true && !gameObject.GetComponent<Animation>().IsPlaying("Killng") && GetComponent<Characters.Enemy>().CurrentCondition !=Characters.Character.Condition.Dead )
        {
            is_able_to_attack = false ;
            gameObject.GetComponent<Characters.Enemy>().canDamage = true;
            if (!music.isPlaying)
            {
                music.clip = Resources.Load("hit_sound") as AudioClip;
                music.time = 0.1f;
                music.Play();
            }
            gameObject.GetComponent<Animation>().Play("Killing");
            cor = StartCoroutine(trigger_wearpon());
        }
        
        

        
    }

    public  void try_to_kill(GameObject target_obj)
    {
        Transform trans_ataker = gameObject.transform;
        Transform trans_target = target_obj.transform;
         direction_agro = trans_target.position - trans_ataker.position;
        if (!(Mathf.Abs(trans_ataker.position.x - trans_target.position.x) + Mathf.Abs(trans_ataker.position.y - trans_target.position.y) <= 2*target_obj.GetComponent<BoxCollider>().size.y / 2))
        {
            if(GetComponent<Characters.Enemy>().MovingAble)
            walk(direction_agro/Mathf.Max(Mathf.Abs( direction_agro.x), Mathf.Abs(direction_agro.y)));
          
        }
        else
        {
            if (!gameObject.GetComponent<Animation>().IsPlaying("Killng"))
            attack();
        }

    }

    public IEnumerator follow_target(GameObject target_object)
    {
        Transform trans_ataker = gameObject.transform;
        Transform trans_target = target_object.transform;
        while(!(Mathf.Abs(trans_ataker.position.x-trans_target.position.x)+ Mathf.Abs(trans_ataker.position.y - trans_target.position.y) <= target_object.GetComponent<BoxCollider>().size.y / 2))
        {
            walk(trans_target.position - trans_ataker.position);
            yield return null;
        }

    }




    public IEnumerator trigger_wearpon()
    {
        while (gameObject.GetComponent<Animation>().IsPlaying("Killing"))
        {




            yield return new WaitForEndOfFrame();


        }
        gameObject.GetComponent<Characters.Enemy>().canDamage = false;
        Debug.Log("Анимация атаки закончена");
        music.Stop();
        yield return new WaitForSeconds(attak_cooldown);
        is_able_to_attack = true;

    }
}
