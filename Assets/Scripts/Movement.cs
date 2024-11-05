using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    private float speed = 4;
    private string weapon;
    private float xvector;
    private float xdir;
    private float ydir;
    private float yvector;
    public PlayerController read;
    public Rigidbody2D body;
    public int onGround = 1;
    //public Collider2D collide;
    private managingdotscript gm;
    public Animator animation;
    private TopDown_AnimatorController axeSwitch;
    private AnimatorStateInfo animInfo;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<managingdotscript>();   
        axeSwitch = GetComponentInChildren<TopDown_AnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {

        animInfo = animation.GetCurrentAnimatorStateInfo(0);
        xdir = Input.GetAxis("Horizontal");
        xvector = xdir * speed;
        transform.position = new Vector3(transform.position.x+(xvector*Time.deltaTime),transform.position.y,transform.position.z);
        ydir = Input.GetAxis("Vertical");
        yvector = ydir * speed;

        if (read.overworld)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y + (yvector * Time.deltaTime), transform.position.z);

        }
        else
        {
            if (Input.GetKeyDown("up")&&onGround>0)
            {
                body.AddForce(new Vector2(0,400));
                //Debug.Log("ahhh");
                onGround -= 1;
            }
            

        }
        //body.AddForce(new Vector2(0, 7));


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "ground")
        {
            onGround = 1;
            //Debug.Log("ouch grass");
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
