using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public managingdotscript gm;
    public TextMeshProUGUI healthText;
    void Start()
    {
        
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<managingdotscript>(); 
       healthText.text = gm.getHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = gm.getHealth().ToString();
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
            
            
    }
    
}
