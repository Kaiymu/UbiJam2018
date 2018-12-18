using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float timer = 5.0f;
    private int timerMinute = 0;
    private int timerSeconde = 0;
    private bool timerEndFlag = false;
    private Text timerText;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!timerEndFlag)
        {
            timer -= Time.deltaTime;
            getMinute();
            getSeconde();
            timerText.text = timerMinute.ToString("00") + ":" + timerSeconde.ToString("00");
            if (timer <= 0.0f)
            {
                timerEnded();
            }
        }

    }

    void getMinute()
    {
        timerMinute = Mathf.FloorToInt(timer / 60);
    }

    void getSeconde()
    {
        timerSeconde = Mathf.FloorToInt(timer % 60);
    }

    void timerEnded()
    {
        timerText.text = "Temps écoulé";
        Debug.Log("TIMER FINI");
        timerEndFlag = true;
    }
}

