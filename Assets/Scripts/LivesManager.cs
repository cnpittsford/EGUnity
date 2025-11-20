using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [Header("Lives")]
    public int maxLives;
    public int lives = 10;
    public bool invincibilityFrames;

    [Header("Counter")]
    public TextMeshProUGUI counter;

    [Header("Debug")]
    public bool invincible;

    public void removeLives(int livesTaken)
    {
        if(!invincibilityFrames && !invincible) {
            lives -= livesTaken;
            counter.text = lives.ToString();
            invincibilityFrames = true;
            Invoke("cancelInvincible", 0.5f);
        }
    }

    void Start()
    {
        counter.text = lives.ToString();
        invincibilityFrames = false;
        maxLives = 10;
    }

    void Update()
    {
        if (counter.text != lives.ToString()) { counter.text = lives.ToString(); }
        if (lives <= 0)
        {
            counter.text = "0";
            SceneManager.LoadScene("Dead");
        }
        if(lives > maxLives)
        {
            regenerateHealth();
        }
    }

    public void cancelInvincible()
    {
        invincibilityFrames = false;
    }

    public void regenerateHealth()
    {
        lives = maxLives;
    }

    public void addMaxHealth()
    {
        maxLives += 1;
        regenerateHealth();
    }
}
