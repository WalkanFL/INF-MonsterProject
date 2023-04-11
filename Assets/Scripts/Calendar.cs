using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{

    public TMP_Text textAsset;

    void Start()
    {
        var day = calendarManager.Instance.Day;
        var month = calendarManager.Instance.Month;

        textAsset.SetText(day + " // " + month);
    }
}
