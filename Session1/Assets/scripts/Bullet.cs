using System.Collections.Generic;
using System.Collections;
using UnityEngine;
 public  class Bullet: MonoBehaviour
{
    public Transform cylinder; // Reference to the cylinder
    public GameObject bulletPrefab; // Bullet prefab (sphere)
    private int shotsTaken = 0;
    public int shotsToDestroy = 10; // Number of shots needed to destroy the cylinder
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Cylinder")
        {
            shotsTaken++;
            if (shotsTaken >= shotsToDestroy)
            {
                Destroy(cylinder.gameObject);
                Debug.Log("You Lose");
            }
            else
            {
                Debug.Log("attacking the cyl");
                ShootBullet();
            }

        }
        void ShootBullet()
        {
            // Instantiate a bullet and shoot towards the cylinder
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.tag = "enemyBullet";
            // OnCollisionEnter();
            rb.velocity = (cylinder.position - transform.position).normalized * 10f; // Adjust speed as needed

            // Destroy the bullet after 1 second
            Destroy(bullet, 1f);
        }
    }
}