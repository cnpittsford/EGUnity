using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Header("Shoot")]
    public GameObject laser;
    public float cooldown;
    public bool cooldownActive;
    public float damage;

    [Header("Player")]
    public Transform player;

    void Start()
    {
        cooldown = 0.25f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !cooldownActive)
        {
            GameObject shot = Instantiate(laser, player.position, laser.transform.rotation);
            shot.tag = "Shooting";
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Vector3 dir = (mouse - shot.transform.position).normalized;
            shot.transform.right = dir;
            SpriteRenderer renderer = shot.GetComponent<SpriteRenderer>();
            renderer.sortingOrder = -5;
            shot.SetActive(true);
            cooldownActive = true;
            Invoke("stopCooldown", cooldown);
        }
    }

    public void stopCooldown()
    {
        cooldownActive = false;
    }
    
    public void decreaseCooldown()
    {
        cooldown -= 0.01f;
        cooldownActive = false;
    }
}