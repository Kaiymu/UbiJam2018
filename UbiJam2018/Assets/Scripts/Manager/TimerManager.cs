using System;
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
    public Text timerText;

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


    public void ChangeText(Text text)
    {
        timerText.gameObject.transform.parent.gameObject.SetActive(false);
        timerText = text;
    }

    public void ResetTimer(float resetTimer) {
        timer = resetTimer;
    }

    void getMinute()
    {
        timerMinute = (int)(timer / 60);
    }

    void getSeconde()
    {
        timerSeconde = (int)(timer % 60);
    }

    void timerEnded()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.END) {
            timerText.text = "Time's up !";
            timerEndFlag = true;
        }
    }
}

