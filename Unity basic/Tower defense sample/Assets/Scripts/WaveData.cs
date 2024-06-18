using UnityEngine;

[CreateAssetMenu(fileName = "wave_", menuName = "Data/WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] MiniWaveData[] miniWaves;
    [SerializeField] float duration;

    public MiniWaveData[] MiniWaves => miniWaves;
    public float Duration => duration;

#if UNITY_EDITOR
    [ContextMenu("Validate data")]
    private void ValidateData()
    {

    }
#endif
}

[System.Serializable]
public class MiniWaveData
{
    [SerializeField] EnemyMiniWaveSpawnData[] enemySpawnDatas;
    [SerializeField] int spawnCount;
    [SerializeField] float duration;
    [SerializeField] float spawnDelay;

    public EnemyMiniWaveSpawnData[] EnemySpawnDatas => enemySpawnDatas;
    public int SpawnCount => spawnCount;
    public float Duration => duration;
    public float SpawnDelay => spawnDelay;
}

[System.Serializable]
public class EnemyMiniWaveSpawnData
{
    [SerializeField] EnemyData enemyData;
    //[SerializeField] int spawnCount;

    public EnemyData EnemyData => enemyData;
    //public int SpawnCount => spawnCount;
}
