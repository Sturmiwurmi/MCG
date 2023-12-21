using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Timer 
{
    static float time;
    //static float duration = 0;
    static bool timeractive;

    static int timerplatzindex = 0;
    static timerTime[] alltimers = new timerTime[20]; // es können 20 verschiedene timer erzeugt werden 
    public static int addtimer(string timername, float duration)
    {
        alltimers[timerplatzindex] = new timerTime(timername, duration);
        timerplatzindex++; 
        if (timerplatzindex> alltimers.Length-1) {
            Debug.LogAssertion("Timerarray muss erweitert werden "); 
        }
        return timerplatzindex-1; // weil schon ++; 
    }
    

    public static void update()
    {
        for (int i = 0; i < alltimers.Length; i++)
        {
            if (alltimers[i] != null)
            {
                timerTime timer = alltimers[i];
                timer.update();
            }
        }
    }

    public static void startTimerwithIndex(int index)
    {
        alltimers[index].starttimer();
    }
    public static float getTimeofTimerwithIndex(int index)
    {
        return alltimers[index].getTime();
    }
    public static string getNameofTimerwithIndex(int index)
    {
        return alltimers[index].getName();
    }
    }
