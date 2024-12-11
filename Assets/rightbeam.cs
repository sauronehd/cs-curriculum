using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightbeam : MonoBehaviour
{
    // Start is called before the first frame update
    int id;
    private static int needed;
    private float size;
    private SpriteRenderer spriteRenderer;
    private forceBeams info;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        size = spriteRenderer.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
