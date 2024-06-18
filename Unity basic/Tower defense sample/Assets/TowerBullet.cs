using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    private Rigidbody rb;
    private float damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ShootBullet(float damage, float projectileSpeed, Vector3 direction)
    {
        this.damage = damage;
        rb.velocity = direction * projectileSpeed;
    }
}
