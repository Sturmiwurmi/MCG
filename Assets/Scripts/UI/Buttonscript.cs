using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonscript : MonoBehaviour
{
    private GameObject gamemanager;
    private GameManager gamemanagerscript;
    public UIcontroller uicontroller;

    void Start()
    {
        gamemanagerscript = gamemanager.GetComponent<GameManager>();
        uicontroller = gamemanagerscript.getuicontroller();
    }
    public void talktonpcbuttonclick()
    {
        uicontroller.enabletalktoNPC(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
