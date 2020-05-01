using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    public float damage; //damage to player
    public float damageRate; //how often damage occurs
    public float pushPlayer; //pushes player away

    float nextDamage; //when the next damage will occur 

    // Start is called before the first frame update
    void Start()
    {
        //nextDamage = 0f; //next damage
        nextDamage = Time.time; //this is another way it can be done
    }

  
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage<Time.time) //checks for player tag and when next damage should occur
        {
            playerHealth healthOfPlayer = other.gameObject.GetComponent<playerHealth>(); //calls for player health script
            healthOfPlayer.addDamage(damage); //adds damage to player health script
            nextDamage = Time.time + damageRate; //checks when next damage should be and calculates time with damage rate

            pushedPlayer(other.transform);
        }
    }

    void pushedPlayer(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized; //pushes the player 
        pushDirection *= pushPlayer; //uses the float variable to push the player
        Rigidbody2D pushRb2d = pushedObject.gameObject.GetComponent<Rigidbody2D>(); //finds player's rigidbody
        pushRb2d.velocity = Vector2.zero; //creates player velocity
        pushRb2d.AddForce(pushDirection, ForceMode2D.Impulse); //adds force to push the player
        print("Damaging");
    }
}
