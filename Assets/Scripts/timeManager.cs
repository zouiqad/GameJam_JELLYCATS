using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : BasicEntityCharacter
{
    private int maxTime;
    private int maxDay;
    private int day;
    private float time;
    private float timeScale;
    private void Start()
    {
        maxTime = 8; // en minutes
        maxDay = 7; // a changer au besoin
        day = 1;
        time = 0f;
        timeScale = 1f;
    }
    private void Update()
    {
        time += Time.deltaTime * timeScale;
    }
    private void changeDay()
    {
        day++;
        if (day > maxDay) { 
            //game over
        }
        else
        {
            setHp(getMaxHp()/2 + day);
        }
    }
}