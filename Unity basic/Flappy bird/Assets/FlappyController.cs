using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour
{
    private const float GroundSpacing = 6.7f;

    [SerializeField] private Camera pCamera;
    [SerializeField] private Transform flappy;
    [SerializeField] private List<Transform> grounds;
    [Header("Config")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D rb;
    private bool isPause;

    private float shiftDistance = 0;
    private Queue<Transform> groundQueue = new Queue<Transform>();
    private float nextGroundPosition = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isPause = false;
        for (int i = 0; i < grounds.Count; i++)
        {
            Transform t = grounds[i];
            groundQueue.Enqueue(t);
        }
        nextGroundPosition = grounds[grounds.Count - 1].position.x + GroundSpacing;
    }

    void Update()
    {
        if (!isPause)
        {
            Move();
            RotateFlappy();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Flap();
            }
            ShiftGround();
        }
    }

    private void ShiftGround()
    {
        if (shiftDistance > GroundSpacing)
        {
            shiftDistance = shiftDistance - GroundSpacing;
            Transform ground = groundQueue.Dequeue();
            ground.position = new Vector3(nextGroundPosition, ground.position.y);
            nextGroundPosition += GroundSpacing;
            groundQueue.Enqueue(ground);
        }
    }

    private void Move()
    {
        Vector3 moveVector = Vector3.right * Time.deltaTime * movementSpeed;
        transform.Translate(moveVector);
        pCamera.transform.Translate(moveVector);
        //cong vao khoang cach nguoi choi di chuyen vao bo dem
        shiftDistance += Time.deltaTime * movementSpeed;
    }

    private void RotateFlappy()
    {
        //Xoay chú chim tới góc -45 độ sử dụng hàm lerp
        flappy.rotation = Quaternion.Lerp(Quaternion.Euler(flappy.rotation.eulerAngles),
            Quaternion.Euler(new Vector3(0, 0, -45)),
            Time.deltaTime * rotationSpeed);
    }

    private void Flap()
    {
        //xoay chu chim len goc 45 do
        flappy.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
        rb.velocity = new Vector3(rb.velocity.x, 0);
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}
