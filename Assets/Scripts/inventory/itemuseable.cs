
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemuseable : MonoBehaviour
{
    [SerializeField] string itemname;
    private int index; 

    [SerializeField] Sprite sprite;
    [SerializeField] float boostitemduration;
    [SerializeField] float ghostmodeduration;
    [SerializeField] int foodchicken;
    [SerializeField] int foodburger; 
    static float timerboostitem;
    static float timerghostitem;

   
    GameObject player;

    private static GameObject teleporterUi;
    void Start()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemsGröhler/" + itemname.ToLower());
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {       
            
            stopboost();
        stopghostmode();
    }
    public static void SetTeleporterUI(GameObject teleporterui)
    {
        teleporterUi = teleporterui;
    }
    public void setIndex(int Index)
    {
     index = Index;
    }
    public int getIndex()
    {
        return index;
    }
    public static void updatetimer() // wird im gamemanager aufgerufen 
    {
        timerboostitem += Time.deltaTime;
        timerghostitem += Time.deltaTime;
    }
    public void setName(string name)
    {
        itemname = name;
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemsGröhler/" + itemname.ToLower());
    }
    public void aktion()
    {
        
        switch (itemname.ToLower())
        {
            case "boost":
                boostitem();                
                break;
            case "geist":
                ghostitem();
                break;
            case "hähnchen":
                player.GetComponent<Playerscript>().addFood(foodchicken);
                break;
            case "burger":
                player.GetComponent<Playerscript>().addFood(foodburger);
                break;
            case "teleporter":
                teleporterUi.SetActive(true);                
                break;

        }
        Destroy(this.gameObject);
    }
    void boostitem()    {
        player.GetComponent<Playerscript>().setSprint(true);
        timerboostitem = 0f;
    }
    private void stopboost()
    {
       
        if (timerboostitem >boostitemduration) 
        {
            player.GetComponent<Playerscript>().setSprint(false);           
           
        }
    }  
    void ghostitem()
    {
        player.GetComponent<Playerscript>().ghostmodeitem(true);
        timerghostitem = 0f;
    }
    void stopghostmode()
    {
       // Debug.Log(player.GetComponent<Playerscript>().Checkcollisionghostmode());
       // Debug.Log(timerghostitem);
        if (timerghostitem > ghostmodeduration && !player.GetComponent<Playerscript>().Checkcollisionghostmode())// funktioniert noch nicht ganz
        {
            player.GetComponent<Playerscript>().ghostmodeitem(false);
        }
    }
}
  
