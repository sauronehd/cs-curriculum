using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float speed = 4;
    private float xvector;
    private float xdir;
    private float ydir;
    private float yvector;
    public PlayerController read;
    public Rigidbody2D body;
    public int onGround = 1;
    public Collider2D collide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                Debug.Log("ahhh");
                onGround -= 1;
            }
            

        }
        //body.AddForce(new Vector2(0, 7));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "ground")
        {
            onGround = 1;
            Debug.Log("ouch grass");
        }
    }
    

    

}
