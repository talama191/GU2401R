using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Vector3 playerDirection
            Vector3 forceDirection = (collision.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(Vector2.right, forceDirection);
            if (angle > 45 && angle < 135)
            {

            }
            else
            {
                PlayerController.Instance.Rigidbody.AddForce(forceDirection * knockbackForce, ForceMode2D.Impulse);
                PlayerController.Instance.DamageReceiver.TakeDamage(1);
            }
        }
    }
}
