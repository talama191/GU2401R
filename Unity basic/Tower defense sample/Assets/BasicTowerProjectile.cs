using UnityEngine;

public class BasicTowerProjectile : TowerProjectile
{
    protected override void OnBulletCollide(Collider other)
    {
        BasicEnemy basicEnemy = other.GetComponent<BasicEnemy>();
        if (basicEnemy != null)
        {
            basicEnemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
