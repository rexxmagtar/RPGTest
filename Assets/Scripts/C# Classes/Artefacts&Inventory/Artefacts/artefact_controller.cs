using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artefact_controller : MonoBehaviour
{
    // Start is called before the first frame update


    public Artefacts.Artefact art;
    void Start()
    {
        art.icon = gameObject.GetComponent<SpriteRenderer>().sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Characters.Wizard>() != null)
        {
            Debug.Log("Артефакт обнаружен!");
            other.gameObject.GetComponent<Characters.Wizard>().add_item_and_update(art);
      
            gameObject.transform.position = new Vector3(1000000, 1000000);
        }
    }
}
