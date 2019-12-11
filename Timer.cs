using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float _Time; // Time per game
    bool isTimeRun = false;  //Switcher of timer

    private GameController gController;
    private UiController uiController;
    

    private void Start()
    {
        gController = transform.GetComponent<GameController>();
        uiController = transform.GetComponent<UiController>();
    }

    public void StartTimer(float time)
    {
        isTimeRun = true;
        _Time = time;
    }


    private void Update()
    {
        uiController.SetTimeLeft(_Time); // Set time at UI
        if (isTimeRun)
        {
            if (_Time > 0)
            {
                _Time -= Time.deltaTime;
            }
            else
            {
                isTimeRun = false;
                gController.Lose(); // if time Out -> Lose
            }
        }
    }
    public float ReturnTime() 
    {
        return _Time;
    }
    public void StopTimer()
    {
        isTimeRun = false;
    }
}
