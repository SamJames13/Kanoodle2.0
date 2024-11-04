using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    bool stopwatchActive = true;
    float currentTime;
    public int startMinutes;

    static private TextMeshProUGUI currTimeText;

    private GridScript gridScript;

    //public HighScore highScore;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        currTimeText = GetComponent<TextMeshProUGUI>();
        gridScript = FindObjectOfType<GridScript>();
        //highScore = FindObjectOfType<HighScore>();
    }

    // Update is called once per frame
    void Update()
    {
        //isDone();
        if (stopwatchActive == true) {
            currentTime = currentTime + Time.deltaTime;
        }
        else {
            HighScore.TRY_SET_HIGH_SCORE(currentTime);
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("D2");
    }

    public void StopStopwatch() {
        stopwatchActive = false;
    }

    // public void isDone() {
    //     // if game is complete, set stopwatchActive to false
    //     //Debug.Log("checking grid");
    //     stopwatchActive = !gridScript.isGridFull();
    // }
}
