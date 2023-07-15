using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{

    int score;
    public Text scoreText;
    public Text scoreText2;
    public float multiplier =5;
    bool stopwatchActive = false;
    float currentTime;
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartStopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatchActive == true){
            currentTime = currentTime + Time.deltaTime;
        }
        score = Mathf.RoundToInt(currentTime * multiplier);
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Minutes.ToString()+":"+time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        
    }

    public void StartStopWatch(){
        stopwatchActive = true;
    }

        public void StopStopWatch(){
        stopwatchActive = false;
    }

}
