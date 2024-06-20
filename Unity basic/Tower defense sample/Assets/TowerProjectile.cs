using System.Collections;
using UnityEngine;
public abstract class TowerProjectile : MonoBehaviour
{
    protected Rigidbody rb;
    protected float damage;

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
            OnBulletCollide(other);

        }
    }

    protected abstract void OnBulletCollide(Collider other);

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
