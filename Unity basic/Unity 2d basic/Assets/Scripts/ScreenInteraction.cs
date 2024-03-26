using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInteraction : MonoBehaviour
{
    [SerializeField] float forceMultiplier;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, LayerMask.GetMask("Interactable"));

            if (hit.collider != null)
            {
                Rigidbody2D rb = hit.collider.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.up * forceMultiplier, ForceMode2D.Impulse);
            }
        }
    }
}
