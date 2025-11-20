using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 0.8f;
    private Transform player;
    private bool active = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        active = true;
    }

    void Update() {
        if (active && player != null)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)dir * speed * Time.deltaTime;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
