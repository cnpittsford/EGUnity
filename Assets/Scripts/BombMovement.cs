using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2.5f;
    private Transform player;
    private bool active = false;

    public bool stopped = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        active = true;
        stopped = false;
    }

    void Update() {
        float distance = Vector2.Distance(gameObject.transform.position, player.position);

        if (active && player != null && distance >= 2.3)
        {
            // Move forward

            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)dir * speed * Time.deltaTime;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            stopped = false;
        } else if(active && player != null && distance <= 1.7) {
            // move backward

            Vector2 dir = (player.position - transform.position).normalized;
            transform.position -= (Vector3)dir * speed * Time.deltaTime;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            stopped = false;
        } else {
            // turn when stopped

            Vector2 dir = (player.position - transform.position).normalized;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            stopped = true;
        }
    }
}
