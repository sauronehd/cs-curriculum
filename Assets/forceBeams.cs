using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceBeams : MonoBehaviour
{

    RaycastHit2D hit;
    
    [SerializeField]float rayLength = 0;
    bool isHit = false;
    string direction;
    [SerializeField]string hitTagUp;
    [SerializeField]string hitTagDown;
    [SerializeField]string hitTagLeft;
    [SerializeField]string hitTagRight;
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
    direction = "up";
    search();

    rayLength = 0;
    isHit = false;
    direction = "down";
    search();

    rayLength = 0;
    isHit = false;
    direction = "left";
    search();

    rayLength = 0;
    isHit = false;
    direction = "right";
    search();
}

void search()
{

while (isHit == false)
    {

            if(direction=="up")
            {
                 hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), rayLength);            
            }
            else if(direction=="down")
            {
                 hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), rayLength);
            }
            else if(direction=="left")
            {
                 hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), rayLength);
            }
            else if(direction=="right")
            {
                 hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), rayLength);

            }
            
        
        if (hit.collider != null)
        {
            
            // Read the tag of the detected object
            string hitTag = hit.collider.tag;
            Debug.Log("Hit object tag: " + hitTag);
            if(direction=="up")
            {
                hitTagUp = hitTag;
            }
            else if(direction=="down")
            {
                hitTagDown = hitTag;
            }
            else if(direction=="left")
            {
                hitTagLeft = hitTag;
            }
            else if(direction=="right")
            {
                hitTagRight = hitTag;

            }
            break;
            //Debug.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector2.up) * rayLength, Color.red);
        }
        else
        {
            rayLength += 0.1f;
        }
    }
}


}

