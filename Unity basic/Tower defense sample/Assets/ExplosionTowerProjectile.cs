using System.Linq;
using UnityEngine;

public class ExplosionTowerProjectile : TowerProjectile
{
    [SerializeField] private float explosionRange;

    protected override void OnBulletCollide(Collider other)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, explosionRange, Vector3.up);
        if (hits.Length > 0)
        {
            BasicEnemy[] enemies = hits.Select(h => h.transform.GetComponent<BasicEnemy>()).Where(b => b != null).ToArray();
            foreach (BasicEnemy enemy in enemies)
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
