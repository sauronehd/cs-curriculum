using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managingdotscript : MonoBehaviour
{

    public static managingdotscript gm ;
    public int coins;
    
    public int hp;
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

    public int getHealth()
    {
        return (hp);
    }

    public void changeHealth(int amt)
    {
        hp += amt;

    }

    public void DEATH()
    {
        print("fucking loser");
        
    }
}
