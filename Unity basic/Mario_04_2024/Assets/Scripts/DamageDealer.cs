﻿using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private const float COOLDOWN = 0.1f;
    [SerializeField] private bool consumeOnCollision = false;
    [SerializeField] private float damage = 1f;
    [SerializeField] private bool knockbackOwner;
    [SerializeField] private float knockbackForce;
    public Character Owner;

    private float timer = 0;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer < 0)
        {
            if (collision.gameObject.tag == "weak_point")
            {
                if (knockbackOwner)
                {
                    Owner.GetComponent<Rigidbody2D>().AddForce(Vector2.up * knockbackForce, ForceMode2D.Impulse);
                }
                DamageReceiver damageReceiver = collision.gameObject.GetComponent<DamageReceiver>();
                damageReceiver.TakeHit(damage);
            }
            timer = COOLDOWN;
            if (consumeOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }

}
