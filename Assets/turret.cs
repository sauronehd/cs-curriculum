using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class turret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float cooldown;
    public GameObject projectiles;
    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= 1 * Time.deltaTime;
        Collider2D[] targets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y),7);
        //print(targets);
        if (cooldown <= 0)
        {
            foreach (var other in targets)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    GameObject obj = Instantiate(projectiles,transform.position,transform.rotation);
                    projectile script = obj.GetComponent<projectile>();
                    script.target = other.gameObject.transform.position;
                    
                    cooldown = 2;

                }
            }
        }
        
        
        
    }
}
