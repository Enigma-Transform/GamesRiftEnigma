using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer1 : MonoBehaviour
{
    [SerializeField]
    float time;
    public bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer == true)
        {
            timerBegin();
        }
    }
    

    public void timerBegin()
    {
        if (time < 10)
        {
            time += Time.deltaTime;
            Debug.Log(time);
        }

        if (time >= 10)
        {
            startTimer = false;
            time = 0;

        }
    }
}
