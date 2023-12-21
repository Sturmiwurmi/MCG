using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilepaletNPCBarrier : MonoBehaviour
{
    public bool TilemaprendererDisableAtStart;
    void Start()
    {
        if (TilemaprendererDisableAtStart) { 
        TilemapRenderer tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapRenderer.enabled = false;
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
