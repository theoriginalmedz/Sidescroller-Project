using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShoot : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D bullRb2d;

    // Start is called before the first frame update
    void Awake()
    {
        bullRb2d = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0)
        
            bullRb2d.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
            else
                bullRb2d.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        

        
    }
        
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeForce()
    {
        bullRb2d.velocity = new Vector2(0, 0);
    }
}
