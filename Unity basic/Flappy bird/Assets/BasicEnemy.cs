using UnityEngine;

public abstract class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;

    private float attackTimer = 0;

    private void Start()
    {
        attackTimer = attackCooldown;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0;
            Attack();
        }
    }

    public abstract void Attack();
}

public class MeleeEnemy : BasicEnemy
{
    public override void Attack()
    {
        //Physics2D.CircleCast();...
    }
}

public class RangedEnemy : BasicEnemy
{
    public override void Attack()
    {
        //Instan
    }
}
