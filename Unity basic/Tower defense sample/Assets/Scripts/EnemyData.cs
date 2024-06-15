using UnityEngine;

[CreateAssetMenu(fileName = "enemy_", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] BasicEnemy enemyPrefab;
    [SerializeField] float maxHp;
    [SerializeField] float movementSpeed;

    public BasicEnemy EnemyPrefab => enemyPrefab;
    public float MaxHp => maxHp;
    public float MovementSpeed => movementSpeed;
}
