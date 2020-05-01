using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float enemSpeed; //Enemy Speed that is changeable 

    Animator enemyAnim; //enemy animations

    //for enemy direction facing
    public GameObject enemyImage; //enemy image 
    bool canFlip = true; //bool to flip the enemy
    bool faceRight = false; //a bool to check if the enemy is facing left or right
    float flipTime = 5f; //per 5 seconds, enemy can flip
    float nextChanceFlip = 0f; //chance of next flip

    //attacking variables
    public float chargingTime; //how long it takes to charge
    float startCharging; //the time to start the charge
    bool charging; //to check the enemy is charging
    Rigidbody2D enemyRB2D; //enemy Rigidbody

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponentInChildren<Animator>(); //checks for the animator component
        enemyRB2D = GetComponent<Rigidbody2D>(); //Enemy Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
     if (Time.time > nextChanceFlip)
        {
            if (Random.Range(0, 10) > 5) flipFace(); //50% chance
            nextChanceFlip = Time.time + flipTime; //every 5 seconds the enemy can flip
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (faceRight && other.transform.position.x < transform.position.x) {
                flipFace(); //when the player enters the trigger the enemy will face their direction
            } else if (!faceRight && other.transform.position.x > transform.position.x)
            {
                flipFace();
            }
            canFlip = false; //once enemy is facing player they won't flip again
            charging = true; //charges at player
            startCharging = Time.time + chargingTime; //checks the time the enemy starts charging
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startCharging < Time.time) //starts charging at the player 
            {
                if (!faceRight) enemyRB2D.AddForce(new Vector2(-1, 0) * enemSpeed); //pushes the enemy towards the player when facing left
                enemyAnim.SetBool("isCharging", charging); //checks animator for isCharging paramater 
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB2D.velocity = new Vector2(0f, 0f); //stops the enemy from charging at the player
            enemyAnim.SetBool("isCharging", charging);
        }
    }

    void flipFace() //new void for flipping which way the enemy is facing
    {
        if (!canFlip) return; //if you can't flip then don't do anything
        float faceX = enemyImage.transform.localScale.x; //checks for the enemy image
        faceX *= -1f; //finds the local scale and flips the image
        enemyImage.transform.localScale = new Vector3(faceX, enemyImage.transform.localScale.y,enemyImage.transform.localScale.z); //flips the image on the x axis
        faceRight = !faceRight;
    }
}
