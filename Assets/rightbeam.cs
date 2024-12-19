using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightbeam : MonoBehaviour
{
    // Start is called before the first frame update
    int id;
    private static float needed;
    private float size;
    private SpriteRenderer spriteRenderer;
    private forceBeams info;
    public GameObject clone;
    public static Transform og;
    void Start()
    {
        info = GameObject.Find("Player").GetComponent<forceBeams>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        size = spriteRenderer.bounds.size.x;
        transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
        if(needed>id)
        {
            GameObject copy = Instantiate(clone, new Vector3(transform.position.x, transform.position.y+size, transform.position.z), Quaternion.identity);
            rightbeam cloneScript = copy.GetComponent<rightbeam>();
            Transform pos = copy.transform;
            pos.rotation = transform.rotation;
            cloneScript.setID(id+1);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(id==0)
        {
            needed = info.upLength/size;
            og = transform;
        }
        else
        {
            transform.position = new Vector3(og.position.x+size*id,og.position.y, og.position.z);
        }
        needed = info.rightLength/size;
        if (needed<id)
        {
            Destroy(gameObject);
        }
        /*
        if(needed>id)
        {
            GameObject copy = Instantiate(clone, this.transform, worldPositionStays:false);
            rightbeam cloneScript = copy.GetComponent<rightbeam>();
            cloneScript.setID(id+1);
        }
        */
    }

    public void setID(int i)
    {
        id = i;
    }
}
