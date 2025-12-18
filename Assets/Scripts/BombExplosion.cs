using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [Header("Exploding")]
    public BombMovement bombMovement;
    public BombBehavior bombBehavior;
    public ParticleSystem explosion;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D explosionCollider;
    public bool played = false;
    public bool stopLoop = false;

    private float exTimer;

    void Update() {
        if(bombMovement.stopped) {
            exTimer += Time.deltaTime;
            if(exTimer >= 1 && stopLoop == false)
            {
                bombMovement.enabled = false;
                bombBehavior.enabled = false;
                explosionCollider.enabled = true;
                explosion.Play();
                played = true;
                spriteRenderer.enabled = false;
                stopLoop = true;
                Invoke("removeBomb", 0.7f);
            }
        }
    }

    public void removeBomb()
    {
        Destroy(gameObject);
    }
}
