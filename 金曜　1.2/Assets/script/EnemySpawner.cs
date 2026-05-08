using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRange = 20f;
    public int maxEnemies = 20;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }
    void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
            return;
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0.5f,
            Random.Range(-spawnRange, spawnRange)
        );
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}

