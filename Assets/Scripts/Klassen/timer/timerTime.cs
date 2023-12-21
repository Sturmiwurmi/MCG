using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerTime
{
    string name; 
    float time;
    float duration = 0;
    bool timeractive;


    public timerTime(string timername, float duration) {
        name = timername;
        time = duration;
    }
    public string getName() { return name; }
    public  void Resettimer() { duration = 0; }
    public  void settimer(int value)
    {
        duration = value;
    }
    public  void starttimer()
    {
        timeractive = true;
    }
    public void pausetimer()
    {
        timeractive = false;
    }

    public void update()
    {
        if (timeractive)
        {
            time += Time.deltaTime;
        }
    }
    public float getTime() { return time; }

    public bool timmerfinished()
    {
        if (time > duration)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
