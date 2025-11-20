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
                explosion.Play();
                played = true;
                spriteRenderer.enabled = false;
                stopLoop = false;
            }
        }
    }
}
