using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public int coins = 0;
    public GameObject coin;
    public TextMeshProUGUI coinText;

    void Start()
    {
        coins = 0;
        coinText.text = "0";
    }

    void Update()
    {
        if(int.Parse(coinText.text) != coins)
        {
            coinText.text = coins.ToString();
        }
    }

    public void spawnCoin(Vector2 pos)
    {
        GameObject coinClone = Instantiate(coin, pos, transform.rotation);
        coinClone.SetActive(true);
    }

    public void addCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }
}
