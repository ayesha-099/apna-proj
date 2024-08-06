using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab for the enemy character
    public Transform[] spawnPoints; // Points where enemies will be spawned
    public Transform[] movePositions; // Positions where the enemies can move randomly
    public GameObject crystalPrefab; // Reference to the crystal prefab
    public GameObject bulletPrefab; // Bullet prefab (sphere)
    private GameObject crystal;

    private List<GameObject> enemies = new List<GameObject>();
    public static EnemySpawner2 Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 2; i++) // Spawn three enemies
        {
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length]; // Ensure spawn points are reused if fewer than three
            // Instantiate the enemy at the spawn point
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();

            // Assign move positions and bullet prefab
            enemyAI.movePositions = movePositions;
            enemyAI.bulletPrefab = bulletPrefab;

            // Instantiate the crystal and assign it to the enemy AI
            //  GameObject crystal = Instantiate(crystalPrefab, spawnPoint.position + Vector3.forward * 2, Quaternion.identity);
            // enemyAI.crystal = crystal.transform; // Assign the instantiated crystal to the enemy AI
            // Assign the existing crystal to the enemy AI
            enemyAI.crystal = GameManager.instance.crystalTransform;

            enemies.Add(enemy); // Add the enemy to the list
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("You win, all enemies destroyed!");
        // Implement any additional end game logic here
    }
}
