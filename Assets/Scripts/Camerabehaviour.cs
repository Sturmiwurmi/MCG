using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class Camerabehaviour : MonoBehaviour
{
    GameObject player;
    public int size; 
    void Start()
    {
       
            player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = player.transform.position;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
       
    }
}
