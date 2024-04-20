using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> points;

    private int currentIndex = 0;
    private bool isReversing = false;

    private Rigidbody2D rb;
    private List<Rigidbody2D> attachedRbs = new List<Rigidbody2D>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveBetweenPoints();
        MoveAttachedObjects();
        //Debug.Log("attached counts " + attachedRbs.Count);
    }

    private void MoveAttachedObjects()
    {
        Vector3 currentPoint = points[currentIndex].position;
        Vector3 v0 = (currentPoint - transform.position).normalized;
        foreach (Rigidbody2D otherRb in attachedRbs)
        {
            otherRb.transform.Translate(v0 * speed * Time.deltaTime);
        }
    }

    private void MoveBetweenPoints()
    {
        Vector3 currentPoint = points[currentIndex].position;

        Vector3 v0 = currentPoint - transform.position;
        if (v0.magnitude < 0.1f)
        {
            if (currentIndex >= points.Count - 1)
            {
                isReversing = true;
            }
            else if (currentIndex <= 0)
            {
                isReversing = false;
            }
            currentIndex += isReversing ? -1 : 1;
            currentPoint = points[currentIndex].position;
        }
        Vector3 directionVector = v0.normalized;
        transform.Translate(directionVector * speed * Time.deltaTime);
    }

    public void AttachRigidbody(Rigidbody2D rb)
    {
        if (!attachedRbs.Contains(rb))
        {
            attachedRbs.Add(rb);
        }
    }

    public void DeattachRigidbody(Rigidbody2D rb)
    {
        attachedRbs.Remove(rb);
    }
}
