using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downbeam : MonoBehaviour
{
    // Start is called before the first frame update
    int id;
    private static float needed;
    private float size;
    private SpriteRenderer spriteRenderer;
    private forceBeams info;
    public GameObject clone;
    void Start()
    {
        info = GameObject.Find("Player").GetComponent<forceBeams>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        size = spriteRenderer.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        needed = info.downLength/size;
        if (needed<id)
        {
            Destroy(gameObject);
        }
        if(needed>id)
        {
            GameObject copy = Instantiate(clone, this.transform, worldPositionStays:false);
            downbeam cloneScript = copy.GetComponent<downbeam>();
            cloneScript.setID(id+1);
        }
    }

    public void setID(int i)
    {
        id = i;
    }
}
