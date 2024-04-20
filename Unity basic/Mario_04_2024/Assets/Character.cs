using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHp;

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
            Destroy(gameObject);
        }
    }
}