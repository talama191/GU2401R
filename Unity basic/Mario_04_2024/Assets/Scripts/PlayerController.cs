using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private DamageDealer bulletPrefab;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private DamageReceiver damageReceiver;
    [Header("Player stat")]
    [SerializeField] private float movevementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float knockbackForce;
    [Header("Attack")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;

    private SpriteRenderer spriteRenderer;
    private MovingPlatform currentPlatform;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private Character character;
    private float attackTimer = 0;
    private bool isFacingLeft;

    public DamageReceiver DamageReceiver => damageReceiver;
    public Rigidbody2D Rigidbody => rb;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        GroundCheck();
        if (character.CanMove)
        {
            MovementControl();
            JumpControl();
            FireControl();
        }
        AnimationControl();
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundCheck.position, 0.05f, Vector2.zero, 0.05f, LayerMask.GetMask("Ground"));

        isGrounded = hit.collider != null;
        if (hit.collider == null)
        {
            if (currentPlatform != null)
            {
                currentPlatform.DeattachRigidbody(rb);
                currentPlatform = null;
            }
            return;
        }
        if (hit.transform.tag == "moving_platform")
        {
            currentPlatform = hit.transform.gameObject.GetComponent<MovingPlatform>();
            currentPlatform.AttachRigidbody(rb);
        }
    }

    private void MovementControl()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");
        float movementValue = inputValue * movevementSpeed;
        rb.velocity = new Vector2(movementValue, rb.velocity.y);

        if (inputValue < 0)
        {
            spriteRenderer.flipX = isFacingLeft = true;
        }
        else if (inputValue > 0)
        {
            spriteRenderer.flipX = isFacingLeft = false;
        }
    }

    private void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FireControl()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            DamageDealer bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 bulletVector = (mousePos - transform.position).normalized;

            //ban thang theo huong nguoi choi chay
            //Vector3 bulletVector = isFacingLeft ? Vector3.left : Vector3.right;
            bulletRb.AddForce(bulletVector * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    private void AnimationControl()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("movement_speed", Mathf.Abs(inputValue));
        animator.SetFloat("vertical_velocity", rb.velocity.y);
        animator.SetBool("is_grounded", isGrounded);
    }
}
