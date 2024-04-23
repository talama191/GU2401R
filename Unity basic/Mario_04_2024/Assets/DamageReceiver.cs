using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    [SerializeField] private Character owner;
    [Header("Knockback")]
    [SerializeField] private bool knockbackOnHit;
    [SerializeField] private float knockbackForce;

    public void TakeHit(float damage, DamageDealer damageDealer)
    {
        if (knockbackOnHit)
        {
            Vector3 knockbackVector = (owner.transform.position - damageDealer.transform.position).normalized;
            knockbackVector += Vector3.up;
            Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();
            rb.AddForce(knockbackVector * knockbackForce, ForceMode2D.Impulse);
        }
        owner.DisableCharacterMovement(0.5f);
        owner.TakeDamage(damage);
    }
}
