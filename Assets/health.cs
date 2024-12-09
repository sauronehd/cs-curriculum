using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public managingdotscript gm;

    void Start()
    {
        gm = FindObjectOfType<managingdotscript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gm.getHealth() < 1)
        {
            gm.DEATH();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.changeHealth(-1);
        }
        else if (other.gameObject.CompareTag("proj"))
        {
            Destroy(other.gameObject);
            gm.changeHealth(-1);
            
        }
            
            
    }
    
}
