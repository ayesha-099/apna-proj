using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CylinderHealth : MonoBehaviour
{
    [SerializeField] private crsHealthBar _healthbar;
    public int maxHealth = 10; // Maximum health (shots it can take)
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        _healthbar.Updatehealthbar(maxHealth, currentHealth);
    }

    public void TakeDamage(int damage)
    {
       
        currentHealth -= damage;
        _healthbar.Updatehealthbar(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("You Lose");
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet with the tag "enemyBullet"
        if (collision.gameObject.CompareTag("enemyBullet"))
        {
            TakeDamage(1); // Reduce health by 1 for each bullet hit
            Debug.Log("Attacking the crstal..");
            Destroy(collision.gameObject); // Destroy the bullet after it hits the cylinder
        }
    }
}
