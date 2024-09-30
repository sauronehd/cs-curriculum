using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position,target, 5*Time.deltaTime);
        
        if (target == transform.position)
        {
            print("detroy");
            Destroy(gameObject);
        }
        
    }
}
