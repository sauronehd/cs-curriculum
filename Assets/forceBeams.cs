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

    public float upLength;
    public float downLength;
    public float leftLength;
    public float rightLength;


    bool w;
    private bool createUp;
    public GameObject upBeamObject;
    bool a;
    bool createLeft;
    public GameObject leftBeamObject;
    bool s;
    bool createDown;
    public GameObject downBeamObject;
    bool d;
    bool createRight;
    public GameObject rightBeamObject;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
{

    w = Input.GetKey(KeyCode.W);
    createUp = Input.GetKeyDown(KeyCode.W);
    a = Input.GetKey(KeyCode.A);
    createLeft = Input.GetKeyDown(KeyCode.A);
    s = Input.GetKey(KeyCode.S);
    createDown = Input.GetKeyDown(KeyCode.S);
    d = Input.GetKey(KeyCode.D);
    createRight = Input.GetKeyDown(KeyCode.D);

    if (!w)
    {
        GameObject[] upBeams = GameObject.FindGameObjectsWithTag("upBeam");
        foreach (GameObject dest in upBeams)
        {
            Destroy(dest);
        }
    }

    if (!s)
    {
        GameObject[] downBeams = GameObject.FindGameObjectsWithTag("downBeam");
        foreach (GameObject dest in downBeams)
        {
          //  Destroy(dest);
        }
        
    }

    if (!a)
    {
        GameObject[] leftBeams = GameObject.FindGameObjectsWithTag("leftBeam");
        foreach (GameObject dest in leftBeams)
        {
            Destroy(dest);
        }
        
    }

    if (!d)
    {
        GameObject[] rightBeams = GameObject.FindGameObjectsWithTag("rightBeam");
        foreach (GameObject dest in rightBeams)
        {
            Destroy(dest);
        }
    }

    if(createUp)
    {
        GameObject madeu = Instantiate(upBeamObject, this.transform, worldPositionStays:false);
        upbeam upBeamScript = madeu.GetComponent<upbeam>();
        upBeamScript.setID(0);
    }
    if(createDown)
    {
        GameObject maded = Instantiate(downBeamObject, this.transform,worldPositionStays:false);
        downbeam downBeamScript = maded.GetComponent<downbeam>();
        downBeamScript.setID(0);
    }
    if(createLeft)
    {
        GameObject madel = Instantiate(leftBeamObject, this.transform, worldPositionStays:false);
        leftbeam leftBeamScript = madel.GetComponent<leftbeam>();
        leftBeamScript.setID(0);
    }
    if(createRight)
    {
        GameObject mader = Instantiate(rightBeamObject, this.transform, worldPositionStays:false);
        rightbeam rightBeamScript = mader.GetComponent<rightbeam>();
        rightBeamScript.setID(0);
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

