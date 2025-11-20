using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinsManager coinsManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pickup();
        }
    }

    public void pickup()
    {
        coinsManager.addCoins(1);
        Destroy(gameObject);
    }
}
