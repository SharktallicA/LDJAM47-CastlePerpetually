// Displays the FPS and SPF to the console debug
// Author: Sean Brennan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleFps : MonoBehaviour
{
    private int frameCount = 0;
    private float timeCount = 0.0f;
    //made public so we can adjust to preference
    public float refreshTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (timeCount < refreshTime)
        {
            timeCount += Time.deltaTime;
            frameCount++;
        }
        else
        {
            float lastFrameRate = frameCount / timeCount;
            float lastSecondRate = timeCount / frameCount;
            frameCount = 0;
            timeCount = 0.0f;
            Debug.Log("FPS: " + lastFrameRate.ToString());
            Debug.Log("SPF: " + lastSecondRate.ToString());
        }
    }
}
