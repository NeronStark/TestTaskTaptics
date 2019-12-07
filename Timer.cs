using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _Time = 5;
    private float extraTime;
    public float ExtraTime { get => extraTime; set => extraTime = value; }
    bool isTimeRun = true;



    private void Update()
    {
        if(isTimeRun)
        {
            if(_Time > 0)
            {
                _Time -= Time.deltaTime;
            }
            else
            {
                isTimeRun = false;
                print("Time is Out");
            }
        }
    }
}
