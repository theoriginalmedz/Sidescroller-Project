using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour

{

    public float damage;

    projectileShoot projectShoot;

    public GameObject explosionEff;

    // Start is called before the first frame update
    void Awake()
    {
        projectShoot = GetComponentInParent<projectileShoot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            projectShoot.removeForce();
            Instantiate(explosionEff, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth enemyHurt = other.gameObject.GetComponent<enemyHealth>();
                enemyHurt.damageAdd(damage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            projectShoot.removeForce();
            Instantiate(explosionEff, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth enemyHurt = other.gameObject.GetComponent<enemyHealth>();
                enemyHurt.damageAdd(damage);
            }
        }


    }
}

