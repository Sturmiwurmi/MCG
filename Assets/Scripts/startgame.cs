using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Foyer");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Player").transform.position = new Vector3(42.56f, 3.6f, 0); ;
       
    }
}
