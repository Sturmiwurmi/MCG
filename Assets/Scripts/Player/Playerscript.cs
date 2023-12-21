using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


public class Playerscript: MonoBehaviour
{
    public Joystick Js;

    public int speed = 3;
    public int sprintspeed = 2;
    public int currentspeed;

    Collider2D lastcollision; 
    //movement
    Rigidbody2D rb;

    //objectslayer für collision
    public LayerMask layerMask;

    // für button
    private bool interaktionmöglich = false; 

    //Gamemanger
    private GameObject gamemanager;
    private GameManager gamemanagerscript;
    public UIcontroller uicontroller;
    private SpriteRenderer spriterenderer;

    public bool getrackt;

    [SerializeField] GameObject Trackpad;

    float timer;
    private Quaternion previousRotation;

    List<item> inventaritems = new List<item>();
    [SerializeField] GameObject UIcontentinv;

    private bool ghostitem; // dass der spieler durch wände gehen kann 
    [SerializeField] int food = 50;

    private bool gröhleritembought;

    private GameObject griesenpc; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gamemanager = GameObject.FindWithTag("Gamemanager");
        gamemanagerscript = gamemanager.GetComponent<GameManager>();
        uicontroller = gamemanagerscript.getuicontroller();
        spriterenderer = GetComponent<SpriteRenderer>();

       

    }


    void Update()
    {
        timer += Time.deltaTime;
        Movement();
        


            starttracking(); // griese ....
       
      
        
    }
    public void SetGröhlerItemBought(bool b)
    {
        gröhleritembought = b;

        //griesenpc initialisieren
        GameObject[] möglicheGriesenpcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject obj in möglicheGriesenpcs)
        {
            if (obj.GetComponent<NPCscript>().getName().Equals("Griese"))
            {
                griesenpc = obj;
                
            }
           
        }
         // wird zwar öfter aufgerufen als nötig, allerdings wird griese nur in der gleichen szene wie gröhler und sein shop rumlaufen 
    }

    public void addFood(int Food)
    {
        if (food > 0)
        {
            food += Food; 
        }
        if (food > 100)
        {
            food = 100;
        }
        Debug.Log(food);
    }
    public int getfood() { return food; }
    public void ghostmodeitem(bool b)
    {
        Color color = spriterenderer.color;
        ghostitem = b;
        if (ghostitem)
        {
            
            color.a = 0.5f; 
           
        }
        else
        {
            color.a = 1f;
        }
        spriterenderer.color = color;
    }
    public List<item> getinvList()
    {
        return inventaritems;
    }
    public void additeminv(item Item)
    {
        inventaritems.Add(Item);
        Item.setIndex(inventaritems.IndexOf(Item));
        UIcontentinv.GetComponent<PlayerInvToUi>().updateListonUI(Item);
    }
    public void removeiteminv(int Index)
    {
        if (inventaritems[Index] != null)
        {
            inventaritems.RemoveAt(Index);
        }
        else
        {
            Debug.Log("!Item existiert nicht. Nichts zu entfernen!");
        }
    }


    public void starttracking()
    {
        if (gröhleritembought&&!getrackt)
        {
            if (getdistancetogriese() < 5)
            {
                getrackt = true;
            }
        }
        if (getrackt&&SceneManager.GetActiveScene().name.Equals("Foyer")) // trackpads sollen nur in der szene gesetzt werden in der sich griese auf befindet 
        {
            getrotationänderung(); // bei jeder drehung soll ein feld plaziert werden
            
        }
    }
    public void endtracking()
    {
        getrackt = false;
        SetGröhlerItemBought(false); 
    }
    private float getdistancetogriese()
    {
        float distance = Vector2.Distance(this.gameObject.transform.position, griesenpc.transform.position); 
       
        return distance;


    }
    public void getrotationänderung()
    {

        // Speichere die aktuelle Rotation des Objekts
        Quaternion currentRotation = transform.rotation;

        // Überprüfe, ob sich die Rotation geändert hat
        if (currentRotation != previousRotation)
        {
            GameObject newObject = Instantiate(Trackpad, transform.position, Quaternion.identity);
        }

        // Aktualisiere die vorherige Rotation
        previousRotation = currentRotation;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastcollision = collision;

       // samplecollisionhandler(collision, "enter");
        NPCcollisionhandler(collision, "enter");
        itemcollisionhandler(collision, "enter");

    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        //samplecollisionhandler(collision, "exit");
        NPCcollisionhandler(collision, "exit");
        itemcollisionhandler(collision, "exit");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    void samplecollisionhandler(Collider2D collision, string Triggerenterexit)
    {
        if (collision.gameObject.CompareTag("..."))
        {
            if (Triggerenterexit.Equals("enter"))
            {
               
            }
            else if (Triggerenterexit.Equals("exit"))
            {
              
            }
        }
    }
    void itemcollisionhandler(Collider2D collision, string Triggerenterexit)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            if (Triggerenterexit.Equals("enter"))
            {
                uicontroller.setinteraktionbuttonpossible(true);
                interaktionmöglich = true;
              
            }
            else if (Triggerenterexit.Equals("exit"))
            {
                uicontroller.setinteraktionbuttonpossible(false);
                interaktionmöglich = false;
            }
        }
    }


    void NPCcollisionhandler(Collider2D collision, string Triggerenterexit)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            if (Triggerenterexit.Equals("enter"))
            {
                uicontroller.aktivatetalkbutton(true);
                uicontroller.Npctalksettext(collision.GetComponent<NPCscript>().getaktuellertex());
                uicontroller.NPCsetSprite(collision.GetComponent<NPCscript>().getsprite());
            }else if (Triggerenterexit.Equals("exit"))
            {
                uicontroller.enabletalktoNPC(false);
                uicontroller.aktivatetalkbutton(false);
                uicontroller.Npctalksettext(null);
                uicontroller.NPCsetSprite(null);
            }
        }
    }

    public void Talktonpctruebuttonmethod()
    {
        uicontroller.enabletalktoNPC(true);
    }
    public void Interagierenbuttonmethod()
    {
        if (interaktionmöglich)
        {
            //lastcollision. -> Collider2D
            Debug.Log("Interagiert");
        }
    }
    bool sprint;
    public void setSprint(bool b)
    {
        if (b)
        {
            currentspeed = speed + sprintspeed;
            sprint = true;
        }
        else
        {
            currentspeed = speed;
            sprint = false; 
        }
    }
    void Movement()
    {
        float horizontalInput;
        float verticalInput;



        
        if (Input.GetKey(KeyCode.LeftShift)||sprint)
        {
            currentspeed = speed + sprintspeed;
        }
        else
        {
           currentspeed = speed;
        }



        if (Js.Horizontal != 0 || Js.Vertical != 0)
        {


            horizontalInput = Js.Horizontal * currentspeed;
            verticalInput = Js.Vertical * currentspeed;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal") * currentspeed;
            verticalInput = Input.GetAxisRaw("Vertical") * currentspeed;

        }

        if (!Checkcollision()||ghostitem)
        {

            rb.velocity = new Vector2(horizontalInput, verticalInput);

            //rotation 
            if (horizontalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -90);
            }
            else if (horizontalInput < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90);
            }

            if (verticalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0);
            }
            else if (verticalInput < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 180);
            }



            if (horizontalInput == verticalInput && verticalInput == currentspeed)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -45);
            }
            else if (horizontalInput == -verticalInput && verticalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 45);
            }
            else if (-horizontalInput == verticalInput && horizontalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -125);
            }
            else if (horizontalInput == verticalInput && horizontalInput == -currentspeed)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 125);
            }
            // rotation ende 



        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public bool Checkcollision()
    {
        Vector2 direction;
        if (Js.Horizontal != 0 || Js.Vertical != 0)
        {
            direction = new Vector2(Js.Horizontal, Js.Vertical).normalized;
        }
        else
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }



        float distance = rb.velocity.magnitude * Time.deltaTime * 2f;

        Collider2D collider2D = GetComponent<Collider2D>();
        Vector2 startPosition = (Vector2)transform.position + collider2D.bounds.extents * direction;

        RaycastHit2D hit = Physics2D.BoxCast(
        startPosition,          // start position of the box cast
        collider2D.bounds.extents,     // size of the box cast
        0f,                     // angle of the box cast
        direction,              // direction of the box cast (based on input axis)
        distance,               // maximum distance to check for collisions
        layerMask);             // layer mask to filter which colliders to check against

        return hit.collider != null;
    }
    public bool Checkcollisionghostmode()
    {
        float radius =1f; // Der Radius des Kreisbereichs
        Collider2D collider2D = GetComponent<Collider2D>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        // Überprüfe, ob ein Kollisionsobjekt mit der gewünschten Layer-Maske gefunden wurde
        if (colliders.Length > 0)
        {
            // Es wurde ein Kollisionsobjekt mit der gewünschten Layer-Maske gefunden
            return true;
        }

        // Kein Kollisionsobjekt mit der gewünschten Layer-Maske gefunden
        return false;
    }
}
