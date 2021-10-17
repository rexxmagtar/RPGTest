using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character;
    void Start()
    {
         Instantiate(character);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
