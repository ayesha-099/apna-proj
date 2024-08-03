using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] movePositions; // Positions where the enemy can move randomly
    public Transform crystal; // Reference to the crystal
    public float attackRange = 5f; // Range within which the enemy will start attacking
    public float attackInterval = 3f; // Time between each attack
    public GameObject bulletPrefab; // Bullet prefab (sphere)
    
    private Rigidbody rb;
    private NavMeshAgent agent;
    private bool isAttacking = false;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Set collision detection mode
        MoveToRandomPosition();
    }

    void Update()
    {
        // Random movement
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToRandomPosition();
        }

        // Attack logic
        if (crystal != null && Vector3.Distance(transform.position, crystal.position) < attackRange)
        {
            if (!isAttacking)
            {
                StartCoroutine(AttackCrystal());
            }
        }
    }

    void MoveToRandomPosition()
    {
        // Move to a random position in the array
        int randomIndex = Random.Range(0, movePositions.Length);
        agent.SetDestination(movePositions[randomIndex].position);
    }

    IEnumerator AttackCrystal()
    {
        isAttacking = true;
        while (true)
        {
            Debug.Log("shooting...");
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(attackInterval / 2); // Adjust if needed to sync with animation timing
            ShootBullet();
            yield return new WaitForSeconds(attackInterval / 2);
        }
    }

    void ShootBullet()
    {
        // Instantiate a bullet and shoot towards the crystal
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.tag = "enemyBullet";
        rb.velocity = (crystal.position - transform.position).normalized * 10f; // Adjust speed as needed

        // Destroy the bullet after 1 second
        Destroy(bullet, 1f);
    }
}
