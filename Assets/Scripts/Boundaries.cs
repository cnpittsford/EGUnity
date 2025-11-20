using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [Header("Bounds")]
    public Vector2 min;
    public Vector2 max;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.transform.position;

            if (pos.x < min.x)
            {
                pos.x = min.x;
            }
            else if (pos.x > max.x)
            {
                pos.x = max.x;
            }

            if (pos.y < min.y)
            {
                pos.y = min.y;
            }
            else if (pos.y > max.y)
            {
                pos.y = max.y;
            }

            other.transform.position = pos;
        }
    }
}
