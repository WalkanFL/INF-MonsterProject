using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endLevelText : MonoBehaviour
{
    public Timer timer;
    public playerPlatformer player;
    public TextMeshProUGUI text;
    void Update()
    {
        if (player.reachedEnd && timer.gotToEndOnTime())
        {
            text.text = "You did it!";
        }
        else if (player.reachedEnd && !timer.gotToEndOnTime())
        {
            text.text = "Failure...";
        }
    }
}
