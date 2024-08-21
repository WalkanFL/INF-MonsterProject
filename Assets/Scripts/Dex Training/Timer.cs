using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI text;
    public playerPlatformer playerPlatformer;
    public float startingTime;
    private float currentTime;
    public bool finishedInTime;
    void Start()
    {
        //currentTime = 1; //debug timer
        currentTime = startingTime - Pet.Instance.dex;
        if (Pet.Instance.dex >= 20)
        {
            currentTime = 5;
        }
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
                text.color = Color.red;
                playerPlatformer.endTraining();
            }
        }

    }


    public void setTimerText()
    {
        text.text = currentTime.ToString("0.00");
    }
}
