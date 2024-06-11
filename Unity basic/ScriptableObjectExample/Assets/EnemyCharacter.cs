using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    SpriteRenderer spriteRDR;
    Animator animator;

    private EnemyConfig config;
    private float currentHP;
    private float baseMovementSpeed;
    private bool hasSetup = false;

    private void Awake()
    {
        spriteRDR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Setup(EnemyConfig config)
    {
        this.config = config;
        currentHP = config.MaxHP;
        spriteRDR.sprite = config.Icon;
        animator.runtimeAnimatorController = config.AnimatorController;

        baseMovementSpeed = config.MovementSpeed;

        hasSetup = true;
    }

    private void Update()
    {
        if (hasSetup)
        {
            transform.position += Vector3.down * baseMovementSpeed * Time.deltaTime;
        }
    }
}