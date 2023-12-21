using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrieseSceenswitch : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneswitching();
    }
    void sceneswitching()
    {
        if (Input.GetKey("1"))
        {

            SceneManager.LoadScene("Foyer");
        }
        if (Input.GetKey("2"))
        {

            SceneManager.LoadScene("Startscreen");
        }
        if (Input.GetKey("3"))
        {

            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKey("8"))
        {

           GameObject.FindWithTag("Player").GetComponent<Playerscript>().getrackt = true;
        }
    }
}
