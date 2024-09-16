using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managingdotscript : MonoBehaviour
{

    public static managingdotscript gm ;
    public int coins;
    // Start is called before the first frame update

    private void Awake()
    {

        if (gm != null)
        {
            Destroy(gameObject);
            return;
        }
        gm = this;
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
