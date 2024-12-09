using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    [SerializeField]private float speed = 4;
    private string weapon;
    private float xvector;
    private float xdir;
    private float ydir;
    private float yvector;
    public PlayerController read;
    public Rigidbody2D body;
    [SerializeField]public bool onGround;
    //public Collider2D collide;
    private managingdotscript gm;
    public Animator animation;
    private TopDown_AnimatorController axeSwitch;
    private AnimatorStateInfo animInfo;
    // Start is called before the first frame update
    int up;
    int down;
    int left;
    int right;
    void Start()
    {
        gm = FindObjectOfType<managingdotscript>();
        axeSwitch = GetComponentInChildren<TopDown_AnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {



        if(Input.GetKey(KeyCode.UpArrow))
        {
            up = 1;
        }
        else
        {
            up = 0;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            down = 1;
        }
        else
        {
            down = 0;
        }   
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            left = 1;
        }
        else
        {
            left = 0;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            right = 1;
        }
        else
        {
            right = 0;
        }

        if (!onGround&&!read.overworld)
        {
            speed-=0.007f;
            if (speed<1)
            {
                speed = 1;
            }
        }
        else
        {
            speed=4;
        }


        animInfo = animation.GetCurrentAnimatorStateInfo(0);
        xdir = right-left;
        xvector = xdir * speed;
        transform.position = new Vector3(transform.position.x+(xvector*Time.deltaTime),transform.position.y,transform.position.z);
        ydir = up-down;
        yvector = ydir * speed;

    
        //body.AddForce(new Vector2(0, 7));



// Right raycast
        Vector2 rightOrigin = new Vector2(transform.position.x + 0.375f, transform.position.y - 0.442f);
        Vector2 rightDirection = new Vector2(0, -1);
        float rayLength = 0.2f;
        RaycastHit2D[] rightCastArray = Physics2D.RaycastAll(rightOrigin, rightDirection, rayLength);
        Debug.DrawLine(rightOrigin, rightOrigin + rightDirection * rayLength, Color.red);

        // Left raycast
        Vector2 leftOrigin = new Vector2(transform.position.x - 0.375f, transform.position.y - 0.442f);
        Vector2 leftDirection = new Vector2(0, -1);
        RaycastHit2D[] leftCastArray = Physics2D.RaycastAll(leftOrigin, leftDirection, rayLength);
        Debug.DrawLine(leftOrigin, leftOrigin + leftDirection * rayLength, Color.blue);

        if (rightCastArray.Length>0||leftCastArray.Length>0)
        {
            onGround = true;
            print("on ground"); 
        }
   

        if (read.overworld)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y + (yvector * Time.deltaTime), transform.position.z);

        }
        else
        {
            if (Input.GetKeyDown("space")&&onGround)
            {
                body.AddForce(new Vector2(0,400));
                Debug.Log("ahhh");
                onGround = false;
            }
            

        }

        if (animInfo.IsName("Shovel_Swing_Horiz") || animInfo.IsName("Shovel_Swing_Down") || animInfo.IsName("Shovel_Swing_Up")|| animInfo.IsName("Axe_Swing_Horiz") || animInfo.IsName("Axe_Swing_Down") || animInfo.IsName("Axe_Swing_Up"))
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x+(xdir*0.7f),transform.position.y+(ydir*0.7f)),0.7f);
        
            foreach (var other in targets)
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    Destroy(other.gameObject);
                   
                }
                else if (other.gameObject.CompareTag("door")&&weapon=="axe")
                {
                    axeSwitch.SwitchToShovel();
                    weapon = "shovel";
                    Destroy(other.gameObject);
                }
            }
        }
        
        
        
    }

    


        
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            gm.chnageCoins(1);
            Object.Destroy(other.gameObject);
        }
        else if (other.tag == "Axe")
        {
            axeSwitch.SwitchToAxe();
            Object.Destroy(other.gameObject);
            print("trigger axe");
            weapon = "axe";
        }
        else if (other.tag == "Shovel")
        {
            axeSwitch.SwitchToShovel();
            Object.Destroy(other.gameObject);

        }
        

    }

}



