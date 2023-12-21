using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class FPScounter : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI m_TextMeshPro;

    private float deltaTime = 0.0f;
    private int fps = 0;

    
    void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the current FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float currentFps = 1.0f / deltaTime;
        fps = (int)currentFps;


        m_TextMeshPro.text = "FPS: " + fps.ToString();       
       
    }
}
