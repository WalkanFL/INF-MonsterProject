using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endLevelText : MonoBehaviour
{
    public Timer timer;
    public playerPlatformer player;
    public TextMeshProUGUI text;
    void Awake()
    {
        if (player.reachedEnd)
        {
            text.text = "You did it!";
        }
        else if (timer.text.color == Color.red)
        {
            text.text = "Failure...";
        }
        else{
            text.text = "huh?";
        }
    }
}
