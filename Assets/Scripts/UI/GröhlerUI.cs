using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GröhlerUI : MonoBehaviour
{
    [SerializeField] GameObject UIGröhler;
    [SerializeField] GameObject ScrollView;
    [SerializeField] GameObject CloseButton;

    

    void Start()
    {
        
        // damit diese canvas im editor nicht die ganze zeit angezeigt wird 
        this.GetComponent<Canvas>().enabled = true;

            ScrollView.SetActive(false);
            CloseButton.SetActive(false);
            UIGröhler.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIGröhler.SetActive(true);
            Debug.Log("ZeigeShopbutton");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIGröhler.SetActive(true);
        }
    }
    public void ShopAn()
    {
        ScrollView.SetActive(true);
    }
    public void ShopAus()
    {
        ScrollView.SetActive(false);
    }
    public void UIAus()
    {
        UIGröhler.SetActive(false);
    }
    public void UIAn()
    {
        UIGröhler.SetActive(true);
    }
    public void CloseButtonOn()
    {
        CloseButton.SetActive(true);
    }
   
    public void CloseButtonOff()
    {
        CloseButton.SetActive(false);
    }
}
