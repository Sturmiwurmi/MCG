using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGröhlerUI : MonoBehaviour
{
    [SerializeField] Canvas UI;
    float timer;
    bool touchingplayer;

    bool einmalausführer = true; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
      

        if(!touchingplayer )
        {
            UI.gameObject.SetActive(false);

        }
        if(touchingplayer&& timer >3 && einmalausführer) {
            einmalausführer = false;
            UI.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer = 0;
            touchingplayer = true;
            UI.GetComponent<GröhlerUI>().CloseButtonOff();
            UI.GetComponent<GröhlerUI>().ShopAus();
           


        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchingplayer = false;
            einmalausführer = true;
        }
    }
}
