using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceBeams : MonoBehaviour
{
    
    [SerializeField]float rayLength = 0;
    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
{
    // Reset rayLength and isHit at the start of each Update
    rayLength = 0;
    isHit = false;

    while (isHit == false)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), rayLength);
        
        if (hit.collider != null)
        {
            isHit = true;
            // Read the tag of the detected object
            string hitTag = hit.collider.tag;
            Debug.Log("Hit object tag: " + hitTag);
        }
        else
        {
            rayLength += 0.1f;
        }
    }

    Debug.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector2.up) * rayLength, Color.red);
    print(rayLength);
}
}
