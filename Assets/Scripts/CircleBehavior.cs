using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    [Header("Behavior")]
    private Transform player;
    private bool active = false;
    public float health;
    public CircleMovement circleMovement;

    [Header("Damage")]
    public ShootingManager shootingManager;
    public ParticleSystem explosion;
    public CoinsManager coinsManager;

    [Header("Debug")]
    public bool activeParticle;
    public bool played;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        active = true;
        activeParticle = false;
        played = false;
    }

    void Update()
    {
        if(active && player != null) {
            if (transform.position.y < -6f || transform.position.y > 6f || transform.position.x < -12f || transform.position.x > 12f)
            {
                Destroy(gameObject);
            }
            if(health <= 0 && !played) {
                circleMovement.enabled = false;
                coinsManager.spawnCoin(transform.position);
                explosion.Play();
                played = true;
                spriteRenderer.enabled = false;
                activeParticle = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Shooting") {
            dealDamage(shootingManager.damage);
            Destroy(other.gameObject);
        }
    }
    public void dealDamage(float damage) {
        health -= damage;
    }

    void OnParticleSystemStopped() {
        if(activeParticle == true) {
            activeParticle = false;
            Destroy(gameObject);
        }
    }
}
