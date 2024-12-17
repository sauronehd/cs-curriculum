using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upbeam : MonoBehaviour
{
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
            GameObject copy = Instantiate(clone, this.transform, worldPositionStays:false);
            upbeam cloneScript = copy.GetComponent<upbeam>();
            cloneScript.setID(id+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        needed = info.upLength/size;
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
