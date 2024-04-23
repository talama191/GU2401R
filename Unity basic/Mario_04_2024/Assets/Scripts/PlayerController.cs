using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float damage;
    [SerializeField] private float movevementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private DamageReceiver damageReceiver;
    [SerializeField] private float knockbackForce;

    private SpriteRenderer spriteRenderer;
    private MovingPlatform currentPlatform;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private Character character;

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
            MovePlayer();
            JumpControl();
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

    private void MovePlayer()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");
        float movementValue = inputValue * movevementSpeed;
        rb.velocity = new Vector2(movementValue, rb.velocity.y);

        if (inputValue < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (inputValue > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
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
