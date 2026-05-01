using UnityEngine;

public class EnemySpawner : MonoBehaviour

{

    public GameObject enemyPrefab;

    public Transform player;

    [Header("Ground Size")]

    public float groundWidth = 50f;

    public float groundLength = 50f;

    [Header("Spawn Settings")]

    public float safeRadius = 10f;

    public float spawnHeight = 1f;

    void Start()

    {

        SpawnEnemy();

    }

    void SpawnEnemy()

    {

        Vector3 spawnPos = Vector3.zero;

        bool validPosition = false;

        while (!validPosition)

        {

            float randomX = Random.Range(-groundWidth / 2, groundWidth / 2);

            float randomZ = Random.Range(-groundLength / 2, groundLength / 2);

            spawnPos = new Vector3(randomX, spawnHeight, randomZ);

            float distance = Vector3.Distance(

                new Vector3(player.position.x, 0, player.position.z),

                new Vector3(spawnPos.x, 0, spawnPos.z)

            );

            if (distance >= safeRadius)

            {

                validPosition = true;

            }

        }

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

    }

}

