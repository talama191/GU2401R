using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private LevelData levelData;

    private bool hasSetup;
    private bool hasFinishSpawning;

    private float waveTimer;
    private float miniWaveTimer;
    private float spawnTimer;

    private int waveIndex;
    private int miniWaveIndex;
    private int enemyDataIndex;
    private int miniWaveSpawnCount;

    private void Start()
    {
        Setup(levelData);
    }

    private void Setup(LevelData levelData)
    {
        //this.levelData = levelData;
        hasSetup = true;
    }

    private void Update()
    {
        if (hasSetup)
        {
            if (hasFinishSpawning) return;
            float dt = Time.deltaTime;
            waveTimer += dt;
            miniWaveTimer += dt;
            spawnTimer += dt;

            WaveData currentWave = levelData.Waves[waveIndex];

            MiniWaveData currentMiniWave = currentWave.MiniWaves[miniWaveIndex];

            ProcessAndSpawnEnemy(currentMiniWave);
            if (miniWaveTimer >= currentMiniWave.Duration)
            {
                MoveNextMiniWave();
            }
            if (waveTimer >= currentWave.Duration)
            {
                MoveNextWave();
            }
        }
    }

    private void ProcessAndSpawnEnemy(MiniWaveData miniWave)
    {
        if (spawnTimer >= miniWave.SpawnDelay)
        {
            if (miniWaveSpawnCount >= miniWave.SpawnCount) return;

            spawnTimer -= miniWave.SpawnDelay;
            var currentEnemyData = miniWave.EnemySpawnDatas[enemyDataIndex];

            SpawnEnemy(currentEnemyData.EnemyData);
            enemyDataIndex++;
            if (enemyDataIndex >= miniWave.EnemySpawnDatas.Length)
            {
                enemyDataIndex = 0;
                miniWaveSpawnCount++;
            }
        }
    }

    private void MoveNextMiniWave()
    {
        WaveData currentWave = levelData.Waves[waveIndex];
        //MiniWaveData currentMiniWave = currentWave.MiniWaves[waveIndex];
        miniWaveIndex++;
        ResetMiniWave();
        if (miniWaveIndex >= currentWave.MiniWaves.Length) MoveNextWave();
    }

    private void MoveNextWave()
    {
        waveIndex++;
        ResetWave();
        if (waveIndex >= levelData.Waves.Length) EndSpawning();

    }

    private void ResetMiniWave()
    {
        miniWaveTimer = 0;
        miniWaveSpawnCount = 0;
        enemyDataIndex = 0;
        spawnTimer = 0;
    }

    void ResetWave()
    {
        waveTimer = 0;
        miniWaveIndex = 0;
        ResetMiniWave();
    }

    private void EndSpawning()
    {
        hasFinishSpawning = true;
    }

    private void SpawnEnemy(EnemyData enemyData)
    {
        Vector3 spawnPos = GameBoard.Instance.StartNode.Position;
        BasicEnemy enemy = Instantiate(enemyData.EnemyPrefab);
        enemy.transform.position = spawnPos;
        enemy.Setup(enemyData);
    }
}
