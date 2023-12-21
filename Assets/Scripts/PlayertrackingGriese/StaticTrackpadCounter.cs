using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticTrackpadCounter 
{
    public static int trackpadnummer;
   
    public static int gettrackpadnummer()
    {
        trackpadnummer++;
        return trackpadnummer;

    }
    public static void resetnummer() { trackpadnummer = 0; }

}
