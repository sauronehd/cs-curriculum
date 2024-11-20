using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxThatGoesDown : MonoBehaviour
{
    // Start is called before the first frame update
    private float up;
    private float down;
    private bool goingUp = true;
    void Start()
    {
        up = transform.position.y;
        down = transform.position.y - 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            if (transform.position.y >= up)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            if (transform.position.y <= down)
            {
                goingUp = true;
            }
        }
    }
}
