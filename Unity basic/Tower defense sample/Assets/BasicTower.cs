using System.Linq;
using UnityEngine;
public class BasicTower : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnRoot;

    private float attackTimer = 0;
    private TowerData data;

    public void Setup(TowerData data)
    {
        this.data = data;
        attackTimer = data.AttackCooldown;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        BasicEnemy[] scannedEnemies = ScanEnemy();

        if (scannedEnemies != null && scannedEnemies.Length > 0)
        {
            if (attackTimer >= data.AttackCooldown)
            {
                var enemyNearestToEnd = scannedEnemies.OrderBy(be => be.GetDistanceToEnd()).FirstOrDefault();
                ShootEnemy(enemyNearestToEnd);
            }
        }
    }

    public void ShootEnemy(BasicEnemy enemy)
    {
        attackTimer = 0;
        TowerProjectile bullet = Instantiate(data.TowerProjectilePrefab);
        bullet.transform.position = bulletSpawnRoot.position;
        Vector3 direction = (enemy.transform.position - bullet.transform.position).normalized;
        bullet.ShootBullet(data.Damage, data.ProjectileSpeed, direction);

        direction.y = 0;
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        transform.rotation = lookDirection;
    }

    public BasicEnemy[] ScanEnemy()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, data.AttackRange, Vector3.up);
        if (hits.Length > 0)
        {
            return hits.Select(h => h.transform.GetComponent<BasicEnemy>()).Where(b => b != null).ToArray();
        }
        return null;
    }
}
