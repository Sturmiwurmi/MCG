using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itembutton : MonoBehaviour
{

    [SerializeField] string itemname;
    [SerializeField] GameObject itemtext;
    [SerializeField] GameObject itemimage;
    
    
    void Start()
    {
       
       itemimage.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemsGröhler/" + itemname.ToLower());
       itemtext.GetComponent<TextMeshProUGUI>().text = itemname;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void setName(string name)
    {
        itemname = name;
        itemimage.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemsGröhler/" + itemname.ToLower());
        itemtext.GetComponent<TextMeshProUGUI>().text = itemname;
    }
    public void pressed()
    {
        // dem spielerinventar das item hinzufügen 
        item invitem = new item(itemname);
        
        GameObject.FindWithTag("Player").GetComponent<Playerscript>().additeminv(invitem);
        GameObject.FindWithTag("Player").GetComponent<Playerscript>().SetGröhlerItemBought(true);
    }
}
