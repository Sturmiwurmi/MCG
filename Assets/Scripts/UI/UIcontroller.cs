using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class UIcontroller : MonoBehaviour
{
    private Image NpcOverlay;

    private TextMeshProUGUI Npctalk;
    private TextMeshProUGUI other;
    private GameObject TalktoNPC;
    private GameObject Interaktionsbutton;
    private Image NPCimage; 
    void Start()
    {
        NpcOverlay = GameObject.FindWithTag("NPCOverlay").GetComponent<Image>();        
        NpcOverlay.enabled = false;

        Npctalk = GameObject.Find("NPCtalk").GetComponent<TextMeshProUGUI>();
        Npctalk.enabled = false;

        TalktoNPC = GameObject.Find("TalktoNPCbutton");
        TalktoNPC.SetActive(false);

        other = GameObject.Find("other").GetComponent<TextMeshProUGUI>();

        Interaktionsbutton = GameObject.Find("Actionbutton");
        
        setinteraktionbuttonpossible(false);

        NPCimage = GameObject.Find("NPCimage").GetComponent<Image>();
        NPCimage.enabled = false;


    }

   public void setinteraktionbuttonpossible(bool booli)
    {
        ColorBlock farbe = Interaktionsbutton.GetComponent<Button>().colors;
        if (booli)
        {            
            farbe.normalColor = Color.white;
            farbe.pressedColor = Color.white;
            farbe.highlightedColor = Color.white;
            farbe.disabledColor = Color.white;
            farbe.selectedColor = Color.white;
            
        }
        else
        {
            farbe.normalColor = Color.grey;
            farbe.pressedColor = Color.grey;
            farbe.highlightedColor = Color.grey;
            farbe.disabledColor = Color.grey;
            farbe.selectedColor = Color.grey;
        }
        Interaktionsbutton.GetComponent<Button>().colors = farbe;
    }
    public void enabletalktoNPC(bool active)
    {
        NpcOverlay.enabled = active;
        Npctalk.enabled = active;
        NPCimage.enabled=active;
        Interaktionsbutton.SetActive(!active);
    }
    public void aktivatetalkbutton(bool pactive)
    {
        TalktoNPC.SetActive(pactive);
    }
    public void Npctalksettext(string ptext)
    {
        Npctalk.text = ptext;
    }
    public void NPCsetSprite(Sprite psprite)
    {
        NPCimage.sprite = psprite;
    }

    void Update()
    {
        
    }
}
