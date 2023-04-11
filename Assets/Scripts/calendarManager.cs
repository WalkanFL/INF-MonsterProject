using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calendarManager : MonoBehaviour
{
    //field
    [SerializeField] protected int day, month;

    //property
    public int Day => day;
    public int Month => month;


    public void progressTime(int timeAmount)
    {
        day += timeAmount;
    }

    void Update()
    {
        if (Day > 30)
        {
            month++;
            day -= 30;
        }

        if (Month > 12)
        {
            month = 1;
            day = 1;
        }
    }

    public static calendarManager Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null) { Destroy(this); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
