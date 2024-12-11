using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
Notes:
Add a prefab to each script that is itself(upbeam gets upBeam, down beam gets downBeam, etc.)
This will allow them to duplicate themselves.

Addprefabs of each beam to this script, so they can be created upon associated key press.

*/


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

    private float upLength;
    private float downLength;
    private float leftLength;
    private float rightLength;


    bool w;
    bool a;
    bool s;
    bool d;
    private LineRenderer line;  

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
void Update()
{

    w = Input.GetKey(KeyCode.W);
    a = Input.GetKey(KeyCode.A);
    s = Input.GetKey(KeyCode.S);
    d = Input.GetKey(KeyCode.D);

    if (w)
    {
        
    }

    if (s)
    {
        
    }

    if (a)
    {
        
    }

    if (d)
    {
        
    }
    


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
                upLength = rayLength;
            }
            else if(direction=="down")
            {
                hitTagDown = hitTag;
                downLength = rayLength;
            }
            else if(direction=="left")
            {
                hitTagLeft = hitTag;
                leftLength = rayLength;
            }
            else if(direction=="right")
            {
                hitTagRight = hitTag;
                rightLength = rayLength;

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

    public float getUpLength()
    {
        return upLength;
    }
    public float getDownLength()
    {
        return downLength;
    }
    public float getLeftLength()
    {
        return leftLength;
    }
    public float getRightLength()
    {
        return rightLength;
    }





}

