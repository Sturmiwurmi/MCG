using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Joystick js;

    public UIcontroller uicontroller;

    
    void Awake()
    {
        player = GameObject.Find("Player");
        instance = this;
        uicontroller = GetComponentInChildren<Canvas>().GetComponent<UIcontroller>();

        DontDestroyOnLoad(this.gameObject);
       
    }
    public UIcontroller getuicontroller()
    {
        return uicontroller;
    }

    void Update()
    {
        sceneswitching();
        Timer.update(); // timer ist vlt nicht benutzt (ist eine eigene klasse) 
        itemuseable.updatetimer();
        

    }

    void sceneswitching()
    {
        if (Input.GetKey("1"))
        {
            
            SceneManager.LoadScene("Foyer");
        }
        if (Input.GetKey("2"))
        {

            SceneManager.LoadScene("41");
        }
        if (Input.GetKey("3"))
        {

            SceneManager.LoadScene("42");
        }
    }
    public void SavePlayer(GameObject playerObject)
    {
        player = playerObject;
    }
    public void SavePlayer()
    {
        player = GameObject.Find("Player");
    }

    public GameObject LoadPlayer()
    {
        return player;
    }

    public Joystick getJs()
    {
        return js;
    }
}
