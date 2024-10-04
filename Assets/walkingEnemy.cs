using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingEnemy : MonoBehaviour
{
    // Start is called before the first frame 
    [SerializeField]private List<Vector3> waypoints;
     int count = 0;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[count], 2*Time.deltaTime);

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
