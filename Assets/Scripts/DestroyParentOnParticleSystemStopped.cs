using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentOnParticleSystemStopped : MonoBehaviour
{
    public BombExplosion bombExplosion;
    public CircleCollider2D explosion;
    private float timer;
    private bool colliderEnable = false;

    void Update() {
        if(bombExplosion.played == true && bombExplosion.stopLoop == false) {
            bombExplosion.stopLoop = true;
            if(colliderEnable == false)
            {
                explosion.enabled = true;
            }
            timer += Time.deltaTime;
            if(timer >= 0.75)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
