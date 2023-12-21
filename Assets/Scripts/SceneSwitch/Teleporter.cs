using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject TeleporterUI; 
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        TeleporterUI.gameObject.SetActive(false);
        itemuseable.SetTeleporterUI(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwtichScene(string scenename)
    {
        if (!scenename.Equals("Foyer2")) // schlecht gelöst es gibt aber zwei spawns für foyer aber nur eine szene
        {
            SceneManager.LoadScene(scenename);
        }
        else
        {
            SceneManager.LoadScene("Foyer"); // foyer szene wird tozdem geladen 
        }
        spawnlocations(scenename);
        
        TeleporterUI.gameObject.SetActive(false);
    }
   private void spawnlocations(string scenename)
    {
        /**
         * spawnlocations der szenen
Foyer: 14.6f, -3.19f
Foyer2: 42.61f, 54.44f
41: -4.67f, -3.64f
42: -4.67f, -3.64f
31: -4.67f, -3.64f
32: -4.67f, -3.64f
21: 25.48f, 63.35f
22: 25.48f, 63.35f
11: 57.5f, 63.58f
12: 25.48f, 63.35f
         * **/
        switch (scenename)
        {
            case "Foyer":
                player.transform.position = new Vector2(14.6f, -3.19f);
                break;
            case "Foyer2":
                player.transform.position = new Vector2(42.61f, 54.44f);
                break;
            case "41":
                player.transform.position = new Vector2(-4.44f, -3.64f);
                break;
            case "42":
                player.transform.position = new Vector2(-4.44f, -3.64f);
                break;
            case "31":
                player.transform.position = new Vector2(-4.44f, -3.64f);
                break;
            case "32":
                player.transform.position = new Vector2(-4.44f, -3.64f);
                break;
            case "21":
                player.transform.position = new Vector2(25.48f, 63.35f);
                break;
            case "22":
                player.transform.position = new Vector2(25.48f, 63.35f);
                break;
            case "11":
                player.transform.position = new Vector2(57.5f, 63.58f);
                break;
            case "12":
                player.transform.position = new Vector2(25.48f, 63.35f);
                break;
        }
      }
}
