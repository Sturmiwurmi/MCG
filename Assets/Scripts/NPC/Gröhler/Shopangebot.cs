using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shopangebot : MonoBehaviour
{
    [SerializeField] GameObject item; 
    void Start()
    {
        addGr�hleritem("Boost");
        addGr�hleritem("H�hnchen");
        addGr�hleritem("Burger");
        addGr�hleritem("Geist");
        addGr�hleritem("Key");
        addGr�hleritem("Teleporter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addGr�hleritem(string name)
    {
        GameObject itemobj = Instantiate(item, transform);
        itemobj.transform.SetParent(transform);
        itemobj.GetComponent<itembutton>().setName(name);
    }
}
