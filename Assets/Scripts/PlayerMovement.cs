using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6.2f;
    public Vector2 minBounds = new Vector2(-10.62f, -4.97f);
    public Vector2 maxBounds = new Vector2(10.62f, 4.97f);

    [Header("Lives")]
    public LivesManager livesManager;

    void Update()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(mx, my, 0f).normalized;

        Vector3 newPos = transform.position + move * speed * Time.deltaTime;

        if (newPos.x < minBounds.x)
        {
            newPos.x = minBounds.x;
        }
        else if (newPos.x > maxBounds.x)
        {
            newPos.x = maxBounds.x;
        }

        if (newPos.y < minBounds.y)
        {
            newPos.y = minBounds.y;
        }
        else if (newPos.y > maxBounds.y)
        {
            newPos.y = maxBounds.y;
        }

        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Triangle"))
        {
            livesManager.removeLives(1);
        }
        if(other.gameObject.CompareTag("Square"))
        {
            livesManager.removeLives(2);
        }
        if(other.gameObject.CompareTag("Circle")) {
            livesManager.removeLives(1);
        }
        if(other.gameObject.CompareTag("Capsule")) {
            livesManager.removeLives(3);
        }
        if(other.gameObject.CompareTag("CapsuleShot")) {
            livesManager.removeLives(1);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Bomb"))
        {
            livesManager.removeLives(1);
        }
        if(other.gameObject.CompareTag("Explode"))
        {
            livesManager.removeLives(3);
        }
        if(other.gameObject.CompareTag("Hexagon"))
        {
            livesManager.removeLives(2);
        }
    }
}