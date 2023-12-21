using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayFoodUI : MonoBehaviour
{
    GameObject Player; 
    TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        Player = GameObject.FindWithTag("Player"); 
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Essen: " + Player.GetComponent<Playerscript>().getfood() + "/100"; 
    }
}
