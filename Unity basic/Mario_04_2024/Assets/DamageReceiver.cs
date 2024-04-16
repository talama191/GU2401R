using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private Transform owner;
    private float currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Destroy(owner.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    DoOnCollisionEnter(collision);
    //}

    //protected abstract void DoOnCollisionEnter(Collision2D collision);
}
