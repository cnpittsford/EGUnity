using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Items")]
    public List<string> items = new List<string>();

    [Header("Text")]
    private string item1;
    public TextMeshProUGUI itemOneTitle;
    public TextMeshProUGUI itemOneAttribute;
    public TextMeshProUGUI itemOneCost;
    private string item2;
    public TextMeshProUGUI itemTwoTitle;
    public TextMeshProUGUI itemTwoAttribute;
    public TextMeshProUGUI itemTwoCost;
    private string item3;
    public TextMeshProUGUI itemThreeTitle;
    public TextMeshProUGUI itemThreeAttribute;
    public TextMeshProUGUI itemThreeCost;

    [Header("Shop")]
    public GameObject shop;
    public bool key;
    public bool open = false;

    [Header("Scripts")]
    public PlayerMovement playerMovement;
    public LivesManager livesManager;
    public ShootingManager shootingManager;
    public CoinsManager coinsManager;

    void Start()
    {
        listCreation();

        firstRoll();

        updateValues();
    }

    void Update()
    {
        key = Input.GetKeyDown(KeyCode.E);

        if(open)
        {
            if(items.Count == 0)
            {
                item1 = null;
                item2 = null;
                item3 = null;
            }
        }

        if (key && !open)
        {
            shop.SetActive(true);
            Time.timeScale = 0.05f;
            playerMovement.enabled = false;
            open = true;
        }
        else if (key && open)
        {
            shop.SetActive(false);
            Time.timeScale = 1f;
            playerMovement.enabled = true;
            open = false;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) && open)
        {
            switch (item1)
            {
                case "Speed": {
                        if (coinsManager.coins >= Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15))
                        {
                            coinsManager.coins -= (int)Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15);
                            playerMovement.speed += 0.5f;
                            reroll1();
                        }
                        break;
                    }
                case "Health": {
                        if (coinsManager.coins >= Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2))
                        {
                            coinsManager.coins -= (int)Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2);
                            livesManager.addMaxHealth();
                            reroll1();
                        }
                        break;
                    }
                case "Attack Speed": {
                        if (coinsManager.coins >= ((Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50))
                        {
                            coinsManager.coins -= (int)(Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50;
                            shootingManager.decreaseCooldown();
                            reroll1();
                        }
                        break;
                    }
            }
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && open)
        {
            switch (item2)
            {
                case "Speed": {
                        if (coinsManager.coins >= Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15))
                        {
                            coinsManager.coins -= (int)Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15);
                            playerMovement.speed += 0.5f;
                            reroll2();
                        }
                        break;
                    }
                case "Health": {
                        if (coinsManager.coins >= Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2))
                        {
                            coinsManager.coins -= (int)Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2);
                            livesManager.addMaxHealth();
                            reroll2();
                        }
                        break;
                    }
                case "Attack Speed": {
                        if (coinsManager.coins >= ((Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50))
                        {
                            coinsManager.coins -= (int)(Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50;
                            shootingManager.decreaseCooldown();
                            reroll2();
                        }
                        break;
                    }
            }
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && open)
        {
            switch (item3)
            {
                case "Speed": {
                        if (coinsManager.coins >= Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15))
                        {
                            coinsManager.coins -= (int)Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15);
                            playerMovement.speed += 0.5f;
                            reroll3();
                        }
                        break;
                    }
                case "Health": {
                        if (coinsManager.coins >= Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2))
                        {
                            coinsManager.coins -= (int)Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2);
                            livesManager.addMaxHealth();
                            reroll3();
                        }
                        break;
                    }
                case "Attack Speed": {
                        if(coinsManager.coins >= ((Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50))
                        {
                            coinsManager.coins -= (int)(Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50;
                            shootingManager.decreaseCooldown();
                            reroll3();
                        }
                        break;
                    }
            }
        }
    }

    public void reroll1()
    {
        item1 = items[Random.Range(0, items.Count)];

        if(playerMovement.speed > 15f && livesManager.maxLives >= 50 && shootingManager.cooldown < 0.05f)
        {
            item1 = null;
        }

        switch(item1)
        {
            case "Speed":
                {
                    if (playerMovement.speed > 15f)
                    {
                        items.Remove("Speed");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            case "Health":
                {
                    if (livesManager.maxLives >= 50)
                    {
                        items.Remove("Health");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            case "Attack Speed":
                {
                    if (shootingManager.cooldown < 0.05f)
                    {
                        items.Remove("Attack Speed");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            default:
                {
                    item1 = null;
                    item2 = null;
                    item3 = null;
                    break;
                }
        }

        updateValues();
    }

    public void reroll2()
    {
        item2 = items[Random.Range(0, items.Count)];

        switch(item2)
        {
            case "Speed":
                {
                    if (playerMovement.speed > 15f)
                    {
                        items.Remove("Speed");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            case "Health":
                {
                    if (livesManager.maxLives >= 50)
                    {
                        items.Remove("Health");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            case "Attack Speed":
                {
                    if (shootingManager.cooldown < 0.05f)
                    {
                        items.Remove("Attack Speed");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            default:
                {
                    item1 = null;
                    item2 = null;
                    item3 = null;
                    break;
                }
        }
        
        updateValues();
    }

    public void reroll3()
    {
        item3 = items[Random.Range(0, items.Count)];

        switch(item3)
        {
            case "Speed":
                {
                    if (playerMovement.speed > 15f)
                    {
                        items.Remove("Speed");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            case "Health":
                {
                    if (livesManager.maxLives >= 50)
                    {
                        items.Remove("Health");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            case "Attack Speed":
                {
                    if (shootingManager.cooldown < 0.05f)
                    {
                        items.Remove("Attack Speed");
                        reroll1();
                        reroll2();
                        reroll3();
                    }
                    break;
                }
            default:
                {
                    item1 = null;
                    item2 = null;
                    item3 = null;
                    break;
                }
        }
        
        updateValues();
    }

    public void updateValues()
    {
        if (item1 != null)
        {
            itemOneTitle.text = item1;
        } else {
            itemOneTitle.text = "Out of Stock"; 
            itemTwoTitle.text = "Out of Stock"; 
            itemThreeTitle.text = "Out of Stock"; 
        }
        if (item2 != null)
        {
            itemTwoTitle.text = item2;
        } else {
            itemOneTitle.text = "Out of Stock"; 
            itemTwoTitle.text = "Out of Stock"; 
            itemThreeTitle.text = "Out of Stock"; 
        }
        if (item3 != null)
        {
            itemThreeTitle.text = item3;
        } else {
            itemOneTitle.text = "Out of Stock"; 
            itemTwoTitle.text = "Out of Stock"; 
            itemThreeTitle.text = "Out of Stock"; 
        }

        switch (item1)
        {
            case "Speed": itemOneAttribute.text = "+0.5 Speed"; itemOneCost.text = Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15).ToString(); break;
            case "Health": itemOneAttribute.text = "+1 HP"; itemOneCost.text = Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2).ToString(); break;
            case "Attack Speed": itemOneAttribute.text = "+0.1 Attack Speed"; itemOneCost.text = ((Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50).ToString(); break;
            default: {
                    itemOneAttribute.text = "...";
                    itemOneCost.text = "0";
                    itemTwoAttribute.text = "...";
                    itemTwoCost.text = "0";
                    itemThreeAttribute.text = "...";
                    itemThreeCost.text = "0";
                    break;
                }
        }
        switch (item2)
        {
            case "Speed": itemTwoAttribute.text = "+0.5 Speed"; itemTwoCost.text = Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15).ToString(); break;
            case "Health": itemTwoAttribute.text = "+1 HP"; itemTwoCost.text = Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2).ToString(); break;
            case "Attack Speed": itemTwoAttribute.text = "+0.1 Attack Speed"; itemTwoCost.text = ((Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50).ToString(); break;
            default: {
                    itemOneAttribute.text = "...";
                    itemOneCost.text = "0";
                    itemTwoAttribute.text = "...";
                    itemTwoCost.text = "0";
                    itemThreeAttribute.text = "...";
                    itemThreeCost.text = "0";
                    break;
                }
        }
        switch (item3)
        {
            case "Speed": itemThreeAttribute.text = "+0.5 Speed"; itemThreeCost.text = Mathf.Round(Mathf.Pow(Mathf.Ceil(playerMovement.speed), 3) / 15).ToString(); break;
            case "Health": itemThreeAttribute.text = "+1 HP"; itemThreeCost.text = Mathf.Pow(Mathf.Floor(livesManager.lives / 5), 2).ToString(); break;
            case "Attack Speed": itemThreeAttribute.text = "+0.1 Attack Speed"; itemThreeCost.text = ((Mathf.Pow(Mathf.Round((shootingManager.cooldown / 2) * 50), 2) * -1) + 50).ToString(); break;
            default: {
                    itemOneAttribute.text = "...";
                    itemOneCost.text = "0";
                    itemTwoAttribute.text = "...";
                    itemTwoCost.text = "0";
                    itemThreeAttribute.text = "...";
                    itemThreeCost.text = "0";
                    break;
                }
        }
    }

    public void firstRoll()
    {
        item1 = items[Random.Range(0, items.Count)];
        item2 = items[Random.Range(0, items.Count)];
        item3 = items[Random.Range(0, items.Count)];
    }

    public void listCreation()
    {
        items.Clear();
        items.Add("Speed");
        items.Add("Health");
        items.Add("Attack Speed");
    }
}
