using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_blast_control : MonoBehaviour
{
    public GameObject atacker;
    public GameObject target;
    public Characters.Enemy target_class;
    public Coroutine cor_fire;
    public Vector2 direction_fire;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("вылетел из " +atacker.transform.position + " в " + atacker.GetComponent<Mage_control1>().mouse_point);
        direction_fire = Camera.main.ScreenToWorldPoint( atacker.GetComponent<Mage_control1>().mouse_point) -atacker.transform.position;
        GetComponent<Rigidbody>().AddForce(direction_fire*100);
        cor_fire = StartCoroutine(destroy(gameObject));
    }

    public IEnumerator destroy(GameObject obj)
    {
        yield return  new WaitForSeconds(5);
        Destroy(obj);
    }
    // Update is called once per frame
    void Update()
    {
        

    }


    public void OnTriggerEnter(Collider other)
    {
         target = other.gameObject;
         target_class=target.GetComponent<Characters.Enemy>();
        Characters.Wizard atacker_class=atacker.GetComponent<Characters.Wizard>();
        Debug.Log("Попал в  " + other.gameObject);
        if (target.GetInstanceID() != atacker.GetInstanceID())
        {
            if (target_class != null)
            {
                Debug.Log("Попал во врага");
                atacker_class.DoFireBall(target_class);
                Debug.Log("Состояние цели :" + target_class.CurrentCondition + " Ее здоровье" + target_class.Hp);
                Destroy(gameObject);
            }
        }
        
    }
}
