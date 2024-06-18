using System.Linq;
using UnityEngine;
public class BasicTower : MonoBehaviour
{
    [SerializeField] TowerBullet bulletPrefab;
    [SerializeField] Transform bulletSpawnRoot;
    [SerializeField] float attackRange;
    [SerializeField] float damage;
    [SerializeField] float attackCooldown;
    [SerializeField] float projectileSpeed;

    private float attackTimer = 0;

    private void Update()
    {
        attackTimer += Time.deltaTime;
        BasicEnemy[] scannedEnemies = ScanEnemy();

        if (scannedEnemies != null && scannedEnemies.Length > 0)
        {
            if (attackTimer >= attackCooldown)
            {
                ShootEnemy(scannedEnemies.FirstOrDefault());
            }
        }
    }

    public void ShootEnemy(BasicEnemy enemy)
    {
        attackTimer = 0;
        TowerBullet bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawnRoot.position;
        Vector3 direction = (enemy.transform.position - bullet.transform.position).normalized;
        bullet.ShootBullet(damage, projectileSpeed, direction);
    }

    public BasicEnemy[] ScanEnemy()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, attackRange, Vector3.up);
        if (hits.Length > 0)
        {
            return hits.Select(h => h.transform.GetComponent<BasicEnemy>()).Where(b => b != null).ToArray();
        }
        return null;
    }
}
