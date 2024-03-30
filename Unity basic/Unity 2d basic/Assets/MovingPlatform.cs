using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float duration;
    private bool hasMove = false;

    private Vector3 distanceFromLastFrame;
    private Vector3 lastFramePosition;

    private Transform attachedObject;

    private void Update()
    {
        distanceFromLastFrame = transform.position - lastFramePosition;
        lastFramePosition = transform.position;
        if (attachedObject != null)
        {
            attachedObject.transform.position += distanceFromLastFrame;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasMove)
        {
            transform.DOMoveX(transform.position.x + distance, duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            hasMove = true;
        }
        attachedObject = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        attachedObject = null;
    }
}
