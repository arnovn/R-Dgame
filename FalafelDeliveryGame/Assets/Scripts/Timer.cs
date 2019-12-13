using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text scoreText;
    private float startTime;
    private bool finished;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (!finished)
        {
            t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            scoreText.text = minutes + ":" + seconds;
        }
    }

    public void SetFinished(bool test)
    {
        finished = test;

    }

    public float GetTime()
    {
        return t;
    }


}
