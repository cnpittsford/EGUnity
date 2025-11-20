using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    void Update() {
        if(transform.position.y < -6f || transform.position.y > 6f || transform.position.x < -12f || transform.position.x > 12f) {
            Destroy(gameObject);
        }

        transform.position += transform.right * speed * Time.deltaTime;
    }
}
