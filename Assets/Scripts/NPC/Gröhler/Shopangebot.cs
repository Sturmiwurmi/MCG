using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shopangebot : MonoBehaviour
{
    [SerializeField] GameObject item; 
    void Start()
    {
        addGröhleritem("Boost");
        addGröhleritem("Hähnchen");
        addGröhleritem("Burger");
        addGröhleritem("Geist");
        addGröhleritem("Key");
        addGröhleritem("Teleporter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addGröhleritem(string name)
    {
        GameObject itemobj = Instantiate(item, transform);
        itemobj.transform.SetParent(transform);
        itemobj.GetComponent<itembutton>().setName(name);
    }
}
