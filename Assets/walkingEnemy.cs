using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingEnemy : MonoBehaviour
{
    // Start is called before the first frame 
    [SerializeField]private List<Vector3> waypoints;
   [SerializeField] public Animator animation;
     int count = 0;
     private Vector3 movingTowards;
    [SerializeField] private float angle;
    void Start()
    {
        //GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        movingTowards = Vector3.MoveTowards(transform.position, waypoints[count], 2*Time.deltaTime);
        
        angle =  MathF.Abs( MathF.Atan(movingTowards.x - transform.position.x/movingTowards.y - transform.position.y));
        
        
        if (angle >= 0 && angle < MathF.PI / 3)
        {
            animation.Play("WalkRight");
            print("right");
        }
        else if (angle >= MathF.PI / 3 && angle <= 2 * MathF.PI / 3)
        {
            animation.Play("WalkUp");
            print("up");
        }
        else if (angle > 2*MathF.PI / 3 && angle <= 4 * MathF.PI / 3)
        {
            animation.Play("WalkLeft");
            print("left");
        }
        else if (angle >= 4*MathF.PI / 3 && angle <= 5 * MathF.PI / 3)
        {
            animation.Play("WalkDown");
            print("down");
        }
        else if (angle >= 5*MathF.PI / 3 && angle <= 2 * MathF.PI )
        {
            animation.Play("WalkRight");
            print("right");
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