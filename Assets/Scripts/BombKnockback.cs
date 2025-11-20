using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKnockback : MonoBehaviour
{
    [Header("Knockback")]
    public float knockbackForce;
    public Rigidbody2D RB;

    void Start() {
        RB.drag = 3f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 knockbackDir = (transform.position - other.transform.position).normalized;
            RB.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Vector2 knockbackDir = (transform.position - other.transform.position).normalized;
            RB.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
