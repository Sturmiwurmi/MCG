using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    
    public float maxMoveTime = 3f;
    public bool npcmovement;

    private Rigidbody2D rb;
    private Vector3 moveDirection;
    private float moveTime;
    private float timer;
    public LayerMask layerMask;
    public LayerMask layerMaskNPC;

    private Vector3 previousPosition;

   

    bool touchingplayer;

    private Vector2 previousVelocity;
    private void Start()
    {
        previousPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        if (npcmovement)
        {
            
            SetNewMoveTime();
            SetNewMoveDirection();
        }

        
        
    }

    private void Update()
    {
        

        
        
        
        if (npcmovement)
        {
            


            timer += Time.deltaTime;

            if (timer >= moveTime)
            {
                SetNewMoveTime();
                randomrotation();
                
                timer = 0f;
            }
            
                MoveNPC();
            
           
            
        }
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    private void randomrotation()
    {
        int random = Random.Range(1, 5);

        switch (random){
            case 1:
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                break;

            case 2:
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
                break;

            case 3:
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
                break;

            case 4:
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
                break;

            default:
                Debug.Log("Fehler in Rotation");
                break;

        }
    }

    private void SetNewMoveTime()
    {
        moveTime = Random.Range(0, 10);
    }

    private void SetNewMoveDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward;
    }

    private void MoveNPC()
    {
        if (!Checkcollision() && !touchingplayer)
        {
            
               

            Vector3 direction = transform.right; // Blickvektor des Objekts in 2D-Szenarien
            direction.z = 0; // Setze die z-Komponente auf 0, um die Bewegung entlang der X- und Y-Achsen zu begrenzen

            direction = Quaternion.Euler(0f,0f,90) * direction;

            rb.velocity = direction.normalized * moveSpeed;



        }
        else
        {
            rb.velocity = Vector3.zero;
        }
       
    }
    
   
     
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
             touchingplayer = true;
            
         }
     }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchingplayer = false;
        }
    }
     
    public Vector2 bestimmeRichtungsvektor()
    {
        Vector2 direction = new Vector2(0, 0);


        // Rotation des Objekts abrufen
        Quaternion rotation = transform.rotation;
        // Die Rotation in EulerAngles umwandeln
        Vector3 eulerRotation = rotation.eulerAngles;

        float Rotation = eulerRotation.z;

        switch (Rotation)
        {
            case 0: // bei rotation von 0° schaut npc nach oben also y+1
                direction = new Vector2(0, 1); break;
            case 90: // bei rotation von 90° schaut npc nach links also x-1
                direction = new Vector2(-1, 0); break;
            case 180: //schaut nach unten
                direction = new Vector2(0, -1); break;
            case 270: //schaut nach rechts
                direction = new Vector2(1, 0); break;
        }
       return direction;
    }
    bool Checkcollision()
    {
        Vector2 direction = bestimmeRichtungsvektor().normalized;

        // Bewegungsvektor berechnen
        Vector3 movementVector = transform.position - previousPosition;

        // Geschwindigkeit berechnen
        float speed = movementVector.magnitude / Time.deltaTime;

        // Vorherige Position aktualisieren
        previousPosition = transform.position;


        float distance = speed * Time.deltaTime * 2f;

        Collider2D collider2D = GetComponent<Collider2D>();
        Vector2 startPosition = (Vector2)transform.position + collider2D.bounds.extents * direction;

        RaycastHit2D hit = Physics2D.BoxCast(
        startPosition,          // start position of the box cast
        collider2D.bounds.extents,     // size of the box cast
        0f,                     // angle of the box cast
        direction,              // direction of the box cast (based on input axis)
        distance,               // maximum distance to check for collisions
        layerMask | layerMaskNPC);             // layer mask to filter which colliders to check against

        return hit.collider != null;
    }
}

