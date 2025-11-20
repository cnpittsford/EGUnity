using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [Header("Exploding")]
    public BombMovement bombMovement;
    public GameObject laser;

    private float shotTimer;

    void Update() {
        if(bombMovement.stopped) {
            shotTimer += Time.deltaTime;
            if(shotTimer >= 2) {
                GameObject shot = Instantiate(laser, gameObject.transform.position, transform.rotation);
                shot.transform.Rotate(0, 0, 90);
                SpriteRenderer renderer = shot.GetComponent<SpriteRenderer>();
                renderer.sortingOrder = -5;
                shot.tag = "CapsuleShot";
                shot.SetActive(true);
                shotTimer = 0;
            }
        }
    }
}
