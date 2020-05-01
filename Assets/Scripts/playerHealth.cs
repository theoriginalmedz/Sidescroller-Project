using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour

{

    public float fullHealth; //player's full health

    float playerCurrentHealth; //player's current health

    PlayerMovement movementForPlayer; //player movement script

    public GameObject playerEffect; //blood effect for death

    //for UI
    public Slider healthSlider; //slider for healthbar
    public Image damageImage; //damage image whenever the player is hurt

    bool playerImageDamaged = false; //the damage image is turned off via a bool
    Color damagedColour = new Color(1f, 1f, 1f, 1f); //turns the alpha of the image back on
    float smoothColour = 3f; //smooths the transition for the image flash
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = fullHealth;

        movementForPlayer = GetComponent<PlayerMovement>(); //accessing the player movement script

        //for UI
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth; //healthslider value matches full health

        playerImageDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (playerImageDamaged)
        {
            damageImage.color = damagedColour; //will turn the alpha on for the image
        } 
       else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear,smoothColour*Time.deltaTime); //turns off the damage alpha colour
          }
        playerImageDamaged = false; //turns off the player damaged image off again
    }

    public void addDamage(float damagePlayer)
    {
        if (damagePlayer <= 0) return; //checks if player is getting damaged
        playerCurrentHealth-=damagePlayer; //subtracts damage from player's health

        healthSlider.value = playerCurrentHealth; //health slider goes down to player's current health
        playerImageDamaged = true; //turns on overlay for damage

        if (playerCurrentHealth <=0) //if player's health is less than 0, they die
        {
            print("DamageTaken");
            killPlayer();
            
        }
    }

    public void addHealth(float healthAdd) //for the health pickup
    {
        playerCurrentHealth += healthAdd; //to add health
        if (playerCurrentHealth > fullHealth) playerCurrentHealth = fullHealth; //checks if the players current health is greated than full health and makes them equal
        healthSlider.value = playerCurrentHealth; //adjusts the health bar 
    }

    public void killPlayer() //kills player and instantiates particle effect
    {
        Instantiate(playerEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
