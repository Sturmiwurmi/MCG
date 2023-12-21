using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trackpadscript : MonoBehaviour
{
    // Start is called before the first frame update
    public int trackpadnumber;

    
    
    void Start()
    {
        trackpadnumber = StaticTrackpadCounter.gettrackpadnummer();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public int getNummer()
    {
        return trackpadnumber;
    }
}
