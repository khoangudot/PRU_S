using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Mảng chứa các loại Enemy
    public float initialSpawnDelay = 2f; // Thời gian chờ trước khi bắt đầu spawn
    public float spawnInterval = 30f; // Khoảng thời gian giữa các lần spawn
    public float spawnIntervalDecreaseRate = 2f; // Tốc độ giảm khoảng thời gian

    private void Start()
    {
        // Gọi hàm SpawnEnemy sau một khoảng thời gian initialSpawnDelay
        StartCoroutine(SpawnEnemy(initialSpawnDelay));
    }

    private IEnumerator SpawnEnemy(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            // Sinh ra một loại Enemy ngẫu nhiên từ mảng enemyPrefabs
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[randomIndex];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            // Giảm khoảng thời gian spawn
            spawnInterval -= spawnIntervalDecreaseRate;

            // Chờ spawn tiếp theo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
