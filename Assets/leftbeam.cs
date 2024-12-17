using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftbeam : MonoBehaviour
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
        transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        needed = info.leftLength/size;
        if (needed<id)
        {
            Destroy(gameObject);
        }
        /*
        if(needed>id)
        {
            GameObject copy = Instantiate(clone, this.transform, worldPositionStays:false);
            leftbeam cloneScript = copy.GetComponent<leftbeam>();
            cloneScript.setID(id+1);
        }
        */
    }

    public void setID(int i)
    {
        id = i;
    }
}
