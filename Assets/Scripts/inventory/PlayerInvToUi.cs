using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInvToUi : MonoBehaviour
{
    [SerializeField] GameObject player;
    List<GameObject> inventaritemsuseable;
    [SerializeField] GameObject itemprefab; 
    void Start()
    {
        inventaritemsuseable = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateListonUI(item Item)    {    

        GameObject itemuseable = Instantiate(itemprefab, transform);
        itemuseable.transform.SetParent(transform);
        itemuseable.GetComponent<itemuseable>().setName(Item.getName());
        itemuseable.GetComponent<itemuseable>().setIndex(Item.getIndex()); 
        inventaritemsuseable.Add(itemuseable);
    }
    
}
