using System.Collections;
using UnityEngine;
public class Character : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private bool isPlayer;

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
        if (isPlayer)
        {
            PlayerInfoUIManager.Instance.UpdateHP(currentHp, maxHp);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            VisualFXManager.Instance.SpawnDisappearEffect(transform.position);
            if (isPlayer)
            {
                //khi người chơi chết
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (animator != null) animator.SetBool("is_taking_damage", true);
        if (isPlayer) PlayerInfoUIManager.Instance.UpdateHP(currentHp, maxHp);
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