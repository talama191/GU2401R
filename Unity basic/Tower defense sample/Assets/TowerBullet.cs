using System.Collections;
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
        StartCoroutine(SelfDestroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            BasicEnemy basicEnemy = other.GetComponent<BasicEnemy>();
            if (basicEnemy != null)
            {
                basicEnemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
