using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upbeam : MonoBehaviour
{
    public static Transform og;
    [SerializeField]int id;
    [SerializeField]private float needed;
    private float size;
    private SpriteRenderer spriteRenderer;
    private forceBeams info;
    public GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("Player").GetComponent<forceBeams>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        size = spriteRenderer.bounds.size.x;
        transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
        needed = info.upLength/size;
        if(needed>id)
        {
            GameObject copy = Instantiate(clone, new Vector3(transform.position.x, transform.position.y+size, transform.position.z), Quaternion.identity);
            upbeam cloneScript = copy.GetComponent<upbeam>();
            Transform pos = copy.transform;
            pos.rotation = transform.rotation;
            cloneScript.setID(id+1);
        }
        print("need:"+needed);
        print("id:"+id);
        if(needed>id)
        {
           print("created");
        }
        else
        {
            print("nope");
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
            transform.position = new Vector3(og.position.x, og.position.y+size*id, og.position.z);
        }
        
        if (needed<id)
        {
            Destroy(gameObject);
        }
        
    
        
    }

    public void setID(int i)
    {
        id = i;
    }
}
