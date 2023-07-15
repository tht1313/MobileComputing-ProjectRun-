using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxhealth;

    public Sprite EmptyHeart;
    public Sprite FullHeart;
    public Image[] hearts;

    public VitaPlayer playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        health = playerHealth.health;
        maxhealth = playerHealth.maxHealth;
        for (int i=0 ; i<hearts.Length;i++){

            if(i<health){
                hearts[i].sprite=FullHeart;
            }

            else{
                hearts[i].sprite = EmptyHeart;
            }
            if(i < maxhealth){
                hearts[i].enabled=true;
            }
            else{
                hearts[i].enabled=false;
            }
        }
        
    }
}
