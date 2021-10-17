using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison_parametrs : MonoBehaviour
{

    public Artefacts.poisoned poison;
    public Vector2 direction_fire;
    public GameObject atacker;
    public Coroutine cor;
    // Start is called before the first frame update
    void Start()
    {
       
        GetComponent<Rigidbody>().AddForce(atacker.GetComponent<Player_move>().direct_*100 );
        cor = StartCoroutine(destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Characters.Enemy>() != null)
        {
            poison.poison_func(other.GetComponent<Characters.Enemy>());
            Destroy(gameObject);
        }   
    }
    public IEnumerator destroy(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        Destroy(obj);
    }
}
