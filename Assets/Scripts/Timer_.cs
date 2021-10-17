using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Timer_ : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public  GameObject  objl;
    public Thread tred;
    public delegate void timer_delegat_handle(GameObject obj);
    public event timer_delegat_handle done_event;
    public timer_delegat_handle func;
    public bool is_ended=false;
    
    public Timer_(int time_t,timer_delegat_handle func_, GameObject object_)
    {
        time = time_t;
        func = func_;
        objl = object_;
        tred = new Thread(thred_func);

    }

    public void thred_func()
    {
        for(int i = 0; i < time; i++)
        {
            Debug.Log("TimeCount");

            Thread.Sleep(1000);
        }
        is_ended = true;
        
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
