using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managingdotscript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public static managingdotscript gm ;
    public int coins;
    public TextMeshProUGUI coinText;
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
        healthText.text = "Health: " + hp;
        coinText.text = "Coins: " + coins;
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
        healthText.text = "Health: " + hp;
    }

    public void DEATH()
    {
        print("fucking loser");
        
    }

    public void chnageCoins(int amt)
    {
        coins += amt;
        coinText.text = "Coins: " + coins;
    }
}
