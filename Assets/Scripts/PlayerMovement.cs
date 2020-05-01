using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variables are placed here
    public float maxSpeed; //maximum Speed of PlayerCharacter

    //jump variables
    bool grounded = false; //checks to see if grounded
    float checkGroundRadius = 0.2f; //checks radius of groundchecker gameobject
    public LayerMask groundLayer; //layerMask for the ground layer
    public Transform groundChecker; //transform for the groundchecker for jumping
    public float jumpHeight; //height of jump

     Rigidbody2D rb2D; //Player's Rigidbody2D
     Animator playerAnim; //The Animator for player animations
     bool RightFacing; //True or false statement to see which direction player is facing 

   
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //Initiliaze Player Rigidbody
        playerAnim = GetComponent<Animator>(); //Initiliaze Player Animator
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation; //freeze the rigidbody rotation

    }

    void Update()
    {
     if(grounded && Input.GetAxis("Jump") > 0)
        {
            playerAnim.SetBool("isGrounded",grounded); //checks to see if grounded is false
            rb2D.AddForce(new Vector2(0, jumpHeight)); //allows the player to jump
        }

     }   
    

    void FixedUpdate()
    {

        //grounded check code, if not then the player is falling
        grounded = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);
        playerAnim.SetBool("isGrounded", grounded); //checks to see if grounded is false


        playerAnim.SetFloat("verticleSpeed", rb2D.velocity.y);

        float playerMovement = Input.GetAxis("Horizontal"); //Player movement is defined on the Horizontal Axis such as the A-D or Arrow Keys
        playerAnim.SetFloat("Speed", Mathf.Abs(playerMovement));
        rb2D.velocity = new Vector2(playerMovement * maxSpeed, rb2D.velocity.y); //Player Velocity - only affects the X axis

        if(playerMovement>0 && RightFacing)
        {
            flipPlayer();
        } else if (playerMovement<0 && !RightFacing)
        {
            flipPlayer(); 
        } //This statement checks to see if the player is moving and which direction they are facing
    }

    void flipPlayer()
    {
        RightFacing = !RightFacing;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1; //Takes the player's scale value and multiplies by negative 1 to face them left;
        transform.localScale = playerScale;
    }
}

