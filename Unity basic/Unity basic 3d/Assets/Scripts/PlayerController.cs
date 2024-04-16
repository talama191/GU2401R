using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;

    private bool isGrounded = false;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector3 cameraOffsetVector;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        cameraOffsetVector = Camera.main.transform.position - transform.position;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.15f, LayerMask.GetMask("Ground"));
        //isGrounded = characterController.isGrounded;

        if (isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0;
        }

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = -Input.GetAxis("Horizontal");

        Vector2 groundDirectionVector = new Vector2(verticalInput, horizontalInput).normalized;
        moveDirection.x = groundDirectionVector.x;
        moveDirection.z = groundDirectionVector.y;

        //Camera.main.transform.position += new Vector3(moveDirection.x, 0, moveDirection.z) * moveSpeed * Time.deltaTime;
        Camera.main.transform.position = transform.position + cameraOffsetVector;

        moveDirection.y += gravity * Time.deltaTime;


        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void test()
    {

    }
}
