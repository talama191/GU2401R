using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    [SerializeField] private Character owner;

    public void TakeHit(float damage)
    {
        owner.TakeDamage(damage);
    }
}
