using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public bool trackingactive;
    bool spielergefangen = false;
    int nexttrackpad = 1; // statictrackpadcounter erhöht die nummer bevor return benutzt wird 
    Vector3 nexttrackpadposition;
    Rigidbody2D rb;

    float movespeed;

    GameObject nexttrackpadobj;
   
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    GameObject player;
    

    List<item> inventaritems; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = GetComponent<NPCMovement>().getMoveSpeed(); // um die gleiche bewegungsgeschwindigkeit wie im anderen script zu haben
        player = GameObject.FindWithTag("Player");
        inventaritems = player.GetComponent<Playerscript>().getinvList();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Trackpad") != null)
        {
            trackingactive = true;
            
           
        }
        tracking();

        if(trackingactive)
        {
            GetComponent<NPCMovement>().npcmovement = false;
            textMeshProUGUI.color = Color.red; 
        }
        else
        {            
            GetComponent<NPCMovement>().npcmovement = true;
            
            textMeshProUGUI.color = Color.white;
        }


        if(spielergefangen){
            endtracking();
            spielergefangen = false; 

        }
    }

   
    public void endtracking()
    {
        
       trackingactive = false;
       

        player.GetComponent<Playerscript>().endtracking();
        rb.velocity = Vector3.zero; // DARF NUR EINMAL AUSGEFÜHRT WERDEN 
        // restlichen trackpads entfernen
        GameObject[] remainingTrackpads = GameObject.FindGameObjectsWithTag("Trackpad");
        foreach (GameObject obj in remainingTrackpads)
        {
            Destroy(obj);
        }
        //damit die trackpads wieder richtig eingesammelt werden 
        nexttrackpad = 1; // 1 weil siehe oben initialisierung 
        StaticTrackpadCounter.resetnummer();

        //zwei random items aus dem spielerinv entfernen
        /**
        for (int i = 0; i < 2; i++)
        {
            int randomindex = Random.Range(0, inventaritems.Count);
            Debug.Log("randomindex: " + randomindex+"inventaritems.count"+ inventaritems.Count); 
            if (inventaritems[randomindex] != null) // -> es kann also auch passieren, dass kein item oder nur ein item entfernt wird
            {
                player.GetComponent<Playerscript>().removeiteminv(randomindex);
            }
        }**/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& trackingactive)
        {
          spielergefangen = true;
            
                       
        }
        
    }
    private void trackpadcollision()
    {
        // wenn der Abstand kleiner als 0.4 ist zählt dies als Kollision 
        if (nexttrackpadobj != null)
        {
            float distance = Vector3.Distance(transform.position, nexttrackpadobj.transform.position);

            //Debug.Log(distance);
            if (distance < 0.4)
            {
                Destroy(nexttrackpadobj);
                nexttrackpad++;
            }
        }
    }
    public bool nexttrackpadexists()
    {
        if (GameObject.FindWithTag("Trackpad") != null)
        {
           return true;
        }
        else
        {
            return false;
        }
    }
   public bool gettrackingactive()
    {
        return trackingactive;
    }
    public void tracking()
    {

        if (trackingactive)
        {
          
            if (nexttrackpadexists())
            {
                

                aktuallisieretrackpadziel();//!! könnte ressourcenlastig sein
                trackpadcollision();


                Vector2 richtungtrackpad = nexttrackpadposition - transform.position;
                rb.velocity = richtungtrackpad.normalized * movespeed;
               
                // Berechnung des Winkels zwischen der Bewegungsrichtung und der X-Achse
                float angle = Mathf.Atan2(richtungtrackpad.y, richtungtrackpad.x) * Mathf.Rad2Deg;

                // Setzen der Z-Rotation des Objekts entsprechend des berechneten Winkels
                transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
            }
            else
            {
                
                // wenn kein trackpad existiert soll zum spieler gelaufen werden 

                Vector2 richtungplayer = player.transform.position - transform.position;
                rb.velocity = richtungplayer.normalized * movespeed;
                
                float angle = Mathf.Atan2(richtungplayer.y, richtungplayer.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
            }
        }
        
    }
    void aktuallisieretrackpadziel()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Trackpad"); //!! könnte ressourcenlastig sein
        foreach (GameObject obj in objectsWithTag)
        {

            if (obj.GetComponent<Trackpadscript>().getNummer() == nexttrackpad)
            {
                nexttrackpadobj = obj;
                nexttrackpadposition = obj.transform.position;
                
            }

        }
    }
}
