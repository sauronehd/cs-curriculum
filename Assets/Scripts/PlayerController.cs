using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public bool overworld; 
    
    private void Start()
    {


        if (SceneManager.GetActiveScene().name == "Start"|| SceneManager.GetActiveScene().name == "Platformer")
        {
            overworld = false;

        }
        else if (SceneManager.GetActiveScene().name == "Overworld")
        {

            overworld = true;
        }


        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        
        
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {





    }

    
    //for organization, put other built-in Unity functions here
    
    
    
    
    
    //after all Unity functions, your own functions can go here
}