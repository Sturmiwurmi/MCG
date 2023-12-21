using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class NPCscript : MonoBehaviour
{
   
    [SerializeField] string Name;
    [SerializeField] private string aktuellertex;
    [SerializeField] Sprite npcsprite;
    [SerializeField] Sprite gameobjectsprite;
    
   
    private Quest questnpc;


   

    void Start()
    {
     
      npcsprite = Resources.Load<Sprite>("NPCPictures/" + Name);
        questnpc = new Quest(Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getName()
    {
        return Name; 
    }
    void  setaktuellertex(string pText)
    {
        aktuellertex = pText;
    }
    public string getaktuellertex()
    {
        aktuellertex = questnpc.getDialogue();
        return aktuellertex;
    }
    public Sprite getsprite()
    {
        return npcsprite;
    }
}
