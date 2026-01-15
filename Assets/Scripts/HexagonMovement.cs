using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    private Transform player;
    private bool active = false;

    private bool isinBox;
    private bool collidingBox;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        active = true;
    }

    void Update() {
        isinBox = getIsInBox();
        if (active && player != null && !isinBox)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)dir * speed * Time.deltaTime;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        } else {
            float angle = 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "HexaCollider")
        {
            collidingBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "HexaCollider")
        {
            collidingBox = false;
        }
    }

    public bool getIsInBox()
    {
        return collidingBox ? true : false;
    }
}
