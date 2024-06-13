using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BasicEnemy enemyPrefab;
    [SerializeField] private float spawnCooldown;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCooldown)
        {
            spawnTimer -= spawnCooldown;
            SpawnEnemy(enemyPrefab);
        }
    }

    private void SpawnEnemy(BasicEnemy enemyPrefab)
    {
        Vector3 spawnPos = GameBoard.Instance.StartNode.Position;
        BasicEnemy enemy = Instantiate(enemyPrefab);
        enemy.transform.position = spawnPos;
        enemy.Setup();
    }
}
