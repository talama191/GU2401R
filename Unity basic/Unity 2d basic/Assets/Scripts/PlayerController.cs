
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float maxHp;
    [SerializeField] private float startingHp;


    private SpriteRenderer playerSprite;
    private Rigidbody2D rb;
    private Animator animator;

    public float CurrentHp { get; private set; }
    public float MaxHp => maxHp;

    private void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (Instance == null)
        {
            Instance = this;
        }
        CurrentHp = startingHp;
    }

    private void Start()
    {
        GameManager.Instance.UIController.UpdateHpUI();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * speed * Time.deltaTime * horizontalInput;

        animator.SetFloat("speed", Mathf.Abs(horizontalInput));

        if (horizontalInput != 0)
        {
            playerSprite.flipX = horizontalInput < 0;
        }

        RaycastHit2D hit = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, 0.05f, LayerMask.GetMask("Ground"));

        if (hit.collider != null && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        var verticalVelocity = rb.velocity.y;
        animator.SetFloat("verticalVelocity", verticalVelocity);
        animator.SetBool("isGrounded", hit.collider != null);

    }

    public void HealPlayer(float amount)
    {
        CurrentHp += amount;
        GameManager.Instance.UIController.UpdateHpUI();
    }
}
