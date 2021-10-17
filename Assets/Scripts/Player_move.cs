using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

[SerializeField]
public class Player_move : MonoBehaviour
{

    public Vector2 direction;
    public float velocity;
    public float velocity_base;
    public bool able_to_move;
    public Vector2 direct_=Vector2.right;/// <summary>
    /// Для получения направлнеия;
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        able_to_move = gameObject.GetComponent<Characters.Wizard>().MovingAble;
        velocity = GetComponent<Characters.Wizard>().speed;
        velocity_base = velocity;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        set_direction();
        Move();

    }
    void Update()
    {
        
       
            
    }

    void set_direction()
    {
        
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            direction = Vector2.up;

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 local_scale = gameObject.transform.localScale;
            gameObject.transform.localScale =new Vector3( Mathf.Abs(gameObject.transform.localScale.x),local_scale.y,local_scale.z);
            

            direction = Vector2.right;
        }

        if (Input.GetKey(KeyCode.S))
            direction = Vector2.down;

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 local_scale = gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), local_scale.y, local_scale.z);



            direction = Vector2.left;
        }


        if (direction == Vector2.left ||direction==Vector2.right)
            direct_ = direction;

    }

    private void Move()
    {
        if (direction != Vector2.zero)
        {
            GetComponent<Animation>()["Walking"].speed =  velocity/15*1.0f;
            GetComponent<Animation>().Play("Walking");

        }

        if (direction == Vector2.zero && GetComponent<Animation>().IsPlaying("Walking"))
            GetComponent<Animation>().Stop();


        gameObject.GetComponent<Rigidbody>().velocity = direction * velocity;
        
    }
}
