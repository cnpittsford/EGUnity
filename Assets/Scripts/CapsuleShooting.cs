using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CapsuleShooting : MonoBehaviour
{
    [Header("Shooting")]
    public CapsuleMovement capsuleMovement;
    public GameObject laser;

    private float shotTimer;

    void Update() {
        if(capsuleMovement.stopped) {
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
