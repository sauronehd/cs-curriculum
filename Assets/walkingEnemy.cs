using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class walkingEnemy : MonoBehaviour
{
    // Start is called before the first frame 
    [SerializeField]private List<Vector3> waypoints;
   [SerializeField] public Animator animation;
     int count = 0;
     private Vector3 movingTowards;
     private float deltaX;
     private float deltaY;
     private bool found;
     private float cooldown;
     private AnimatorStateInfo stateInfo; 
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = animation.GetCurrentAnimatorStateInfo(0);
        
        cooldown -= 1 * Time.deltaTime;
        
        movingTowards = Vector3.MoveTowards(transform.position, waypoints[count], 2*Time.deltaTime);
        
        Collider2D[] targets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y),7);
        
        foreach (var other in targets)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
                movingTowards =  Vector3.MoveTowards(transform.position,other.gameObject.transform.position,2*Time.deltaTime) ;
                
                found = true;
            }
        }
        
        
        
        deltaX = movingTowards.x - transform.position.x;
        deltaY = movingTowards.y - transform.position.y;

        if (stateInfo.IsName("WalkUp")||stateInfo.IsName("WalkDown")||stateInfo.IsName("WalkRight")||stateInfo.IsName("WalkLeft"))
        {
            if (MathF.Abs(deltaY) > MathF.Abs(3 * deltaX))
            {
                if (deltaY < 0)
                {
                    animation.Play("WalkDown");
                }
                else if (deltaY > 0)
                {
                    animation.Play("WalkUp");
                }

            }
            else
            {
                if (deltaX < 0)
                {
                    animation.Play("WalkLeft");
                }
                else if (deltaX > 0)
                {
                    animation.Play("WalkRight");
                }
            }
        }



        if (found)
        {
            targets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y),1);
            foreach (var other in targets)
            {
                if (other.gameObject.CompareTag("Player")&&cooldown<=0)
                {
                
                    if (MathF.Abs(deltaY )>MathF.Abs( 3 * deltaX))
                    {
                        if (deltaY < 0)
                        {
                            animation.Play("AttackDown");
                            //print("attack down");
                        }
                        else if (deltaY > 0)
                        {
                            animation.Play("AttackUp");
                            //print("attack up");
                        }
            
                    }
                    else
                    {
                        if (deltaX < 0)
                        {
                            animation.Play("AttackLeft");
                            //print("attack left");
                        }
                        else if (deltaX > 0)
                        {
                            animation.Play("AttackRight");
                            //print("attack right");
                        }
                        
                        
                    }
                    
                    cooldown = 2;
                    managingdotscript gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<managingdotscript>();
                    gm.changeHealth(-1);

                }
            }
        }

        
        
        
        
        transform.position = movingTowards;
        
        
        
        if (transform.position == waypoints[count])
        {
            count += 1;
            if (count > 5)
            {
                count = 0;
            }
        }

    }


}


//Degress 60 to 120, face up
//Degrees 240 t 300, face down. 
//Otherise, face left/right