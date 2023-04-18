using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timer;
    public playerPlatformer playerPlatformer;
    public float startingTime;
    private float currentTime;
    public bool finishedInTime;
    void Start()
    {
        currentTime = startingTime - Pet.Instance.dex;
    }
    void Update()
    {
        if (!playerPlatformer.reachedEnd)
        {
            setTimerText();
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                timer.color = Color.red;
            }
        }

    }

    public bool gotToEndOnTime()
    {
        if (currentTime > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setTimerText()
    {
        timer.text = currentTime.ToString("0.00");
    }
}
