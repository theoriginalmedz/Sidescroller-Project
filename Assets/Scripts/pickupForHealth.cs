using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupForHealth : MonoBehaviour
{

    public float healthAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //checks for players tag via the collider
        {
            playerHealth pHealth = other.gameObject.GetComponent<playerHealth>(); //finding the player health script for reference
            pHealth.addHealth(healthAmount); //adds health via the adjustable float in this script
            Destroy(gameObject); //destroys the heart icon once picked up
        }

    }
}
