using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_control : MonoBehaviour
{
    public float secs;
    public Coroutine cor;
    // Start is called before the first frame update
    void Start()
    {
        cor = StartCoroutine(cool());
    }

    public IEnumerator cool()
    {
        yield return new WaitForSeconds(secs);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
