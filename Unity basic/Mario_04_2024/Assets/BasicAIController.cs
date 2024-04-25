using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIController : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float detectionRange;
    [SerializeField] private float chaseLimit;

    private SpriteRenderer sprite;
    private AIState currentState = AIState.Patrol;
    private int currentIndex = 0;
    private bool isReversing = false;
    private float currentSpeed;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case AIState.Patrol:
                Patrol();
                break;
            case AIState.Chase:
                Chase();
                break;
        }

        if (currentSpeed != 0) sprite.flipX = currentSpeed > 0 ? false : true;
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        Vector3 detectionVector = (Vector3.right * currentSpeed).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, detectionVector, detectionRange, LayerMask.GetMask("Player"));
        Debug.DrawLine(transform.position, transform.position + detectionVector * detectionRange, Color.green);
        if (currentState == AIState.Patrol && hit.collider != null)
        {
            currentState = AIState.Chase;
        }
    }

    private void Chase()
    {
        Vector3 directionVector = (PlayerController.Instance.transform.position - transform.position);
        if (directionVector.magnitude > chaseLimit) currentState = AIState.Patrol;
        directionVector.y = 0;
        Move(directionVector);


    }

    private void Patrol()
    {
        Vector3 currentPoint = patrolPoints[currentIndex].position;

        Vector3 directionVector = currentPoint - transform.position;
        directionVector.y = 0;
        if (directionVector.magnitude < 0.1f)
        {
            if (currentIndex >= patrolPoints.Length - 1)
            {
                isReversing = true;
            }
            else if (currentIndex <= 0)
            {
                isReversing = false;
            }
            currentIndex += isReversing ? -1 : 1;
            currentPoint = patrolPoints[currentIndex].position;
        }
        Move(directionVector);
    }

    private void Move(Vector3 directionVector)
    {
        directionVector.Normalize();
        transform.Translate(directionVector * speed * Time.deltaTime);
        currentSpeed = directionVector.x * speed;
    }
}

public enum AIState
{
    Patrol,
    Chase
}
