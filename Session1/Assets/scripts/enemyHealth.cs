using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 2; // Maximum health (shots it can take)
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("You win");
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet with the tag "playerBullet"
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            TakeDamage(1); // Reduce health by 1 for each bullet hit
            Debug.Log("Attacking the enemy...");
            Destroy(collision.gameObject); // Destroy the bullet after it hits the cylinder
        }
    }
    // Update is called once per frame
    
}
