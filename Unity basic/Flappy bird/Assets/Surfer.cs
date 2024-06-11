using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Surfer : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] Transform playerVisual;
    [SerializeField] float rotateDuration;
    [SerializeField] int rotateCount;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }
    }

    public void DoJump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playerVisual.DORotate(transform.rotation.eulerAngles + new Vector3(0, 0, 360) * rotateCount, rotateDuration, RotateMode.FastBeyond360);
    }
}
