using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float maxHealth; //enemy max health

    float currentHealth;  //current health of enemy

    public GameObject enemyDeathEffect; //effect for enemy death

    public Slider enemyHealthBar; //enemy health bar

    void Start()
    {
        currentHealth = maxHealth; //the health of the enemy
        enemyHealthBar.maxValue = currentHealth; //health bar is current value
        enemyHealthBar.value = currentHealth; //health bar's value is the current health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageAdd(float damage)
    {
        enemyHealthBar.gameObject.SetActive(true); //turns on the enemy health bar per damage
        currentHealth -= damage; //the current health is deducted by damage
        enemyHealthBar.value = currentHealth; //so the slider shows the enemy's current health
        if (currentHealth <= 0) killEnemy(); //if health reaches 0, kill the enemy
    }

    void killEnemy()
    {
        Destroy(gameObject);
    }
}
