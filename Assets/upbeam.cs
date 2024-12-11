using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upbeam : MonoBehaviour
{
    int id;
    private static int needed;
    private float size;
    private SpriteRenderer spriteRenderer;
    private forceBeams info;
    // Start is called before the first frame update
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
