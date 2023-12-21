using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Foyer
    string currentscene; 
    public string scenewitch;
    public float movex;
    public float mevey;

    BoxCollider2D bc; 
    void Start()
    {
        currentscene = SceneManager.GetActiveScene().name;
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Swtichtriggerenter");
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x + movex, collision.gameObject.transform.position.y + mevey, 0);
           collision.gameObject.transform.position = new Vector3( movex, mevey, collision.gameObject.transform.position.y);
           

            SceneManager.LoadScene(scenewitch);
            Debug.Log("Swtichto" + scenewitch);
        }
    }
}
