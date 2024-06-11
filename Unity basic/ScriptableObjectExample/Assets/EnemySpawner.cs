using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyConfig> enemyConfigs;
    //[SerializeField] private EnemyCharacter enemyPrefab;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        foreach (Transform point in spawnPoints)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemyConfigs.Count);
            EnemyConfig config = enemyConfigs[randomIndex];

            EnemyCharacter character = Instantiate(config.CharacterPrefab, point);
            character.transform.localPosition = Vector3.zero;

            character.Setup(config);
        }
    }
}
