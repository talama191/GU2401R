using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHp;

    private bool canMove;
    private float currentHp;
    private Animator animator;

    public bool CanMove => canMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHp = maxHp;
        canMove = true;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            VisualFXManager.Instance.SpawnDisappearEffect(transform.position);
            Destroy(gameObject);
        }
        if (animator != null) animator.SetBool("is_taking_damage", true);
    }

    public void DisableCharacterMovement(float duration)
    {
        canMove = false;
        StartCoroutine(ReEnableMovement(duration));
    }

    IEnumerator ReEnableMovement(float duration)
    {
        yield return new WaitForSeconds(duration);
        canMove = true;
        if (animator != null) animator.SetBool("is_taking_damage", false);
    }
}