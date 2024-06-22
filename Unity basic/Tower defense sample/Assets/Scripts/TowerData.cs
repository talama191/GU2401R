using UnityEngine;

[CreateAssetMenu(fileName = "tower_", menuName = "Data/Tower Data")]
public class TowerData : ScriptableObject
{
    [SerializeField] Sprite icon;
    [SerializeField] string towerName;
    [SerializeField] BasicTower towerPrefab;
    [SerializeField] TowerProjectile towerProjectilePrefab;
    [SerializeField] float attackRange;
    [SerializeField] float damage;
    [SerializeField] float attackCooldown;
    [SerializeField] float projectileSpeed;

    public Sprite Icon => icon;
    public string TowerName => towerName;
    public BasicTower TowerPrefab => towerPrefab;
    public TowerProjectile TowerProjectilePrefab => towerProjectilePrefab;
    public float AttackRange => attackRange;
    public float Damage => damage;
    public float AttackCooldown => attackCooldown;
    public float ProjectileSpeed => projectileSpeed;
}
