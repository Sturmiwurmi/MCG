using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class item 
{
    [SerializeField] string itemname;
   
    
    int indexininv = 99999999;
   
    public item(string name)
    {
        itemname = name;
    }
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setIndex(int index)
    {
        indexininv = index;
    }
    public int getIndex()
    {
        return indexininv;
    }
    public void setName(string name)
    {
        itemname = name;       
    }
    public string getName()
    {
        return itemname;
    }
  
}

