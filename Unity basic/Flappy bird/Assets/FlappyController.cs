using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlappyController : MonoBehaviour
{
    [SerializeField] private Camera pCamera;
    [SerializeField] private Transform flappy;
    [Header("Config")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D rb;
    private bool isPause;
    private State state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isPause = false;
        state = State.Playing;
    }

    void Update()
    {
        switch (state)
        {
            case State.Standby:
                break;
            case State.Playing:
                Move();
                RotateFlappy(-45);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Flap();
                }
                break;
            case State.Gameover:
                RotateFlappy(-90, 5);
                break;

        }
    }

    private void Move()
    {
        Vector3 moveVector = Vector3.right * Time.deltaTime * movementSpeed;
        transform.Translate(moveVector);
        pCamera.transform.Translate(moveVector);
        //cong vao khoang cach nguoi choi di chuyen vao bo dem
        LevelGenerator.Instance.ShiftDistance += Time.deltaTime * movementSpeed;
        LevelGenerator.Instance.ObstacleSpawnTimer += Time.deltaTime * movementSpeed;
    }

    private void RotateFlappy(float zDegree, float factor = 1)
    {
        //Xoay chú chim tới góc zDegree độ sử dụng hàm lerp
        flappy.rotation = Quaternion.Lerp(Quaternion.Euler(flappy.rotation.eulerAngles),
            Quaternion.Euler(new Vector3(0, 0, zDegree)),
            Time.deltaTime * rotationSpeed * factor);
    }

    private void Flap()
    {
        //xoay chu chim len goc 45 do
        flappy.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
        rb.velocity = new Vector3(rb.velocity.x, 0);
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

        AudioManager.Instance.PlayJumpClip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            state = State.Gameover;
            gameObject.layer = LayerMask.NameToLayer("Dead");
            AudioManager.Instance.PlayDeadClip();
        }
    }

    public enum State
    {
        Standby,
        Playing,
        Gameover
    }
}
