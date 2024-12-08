using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{   
    public static CoinManager instance;
    public TMP_Text coinsDisplay;
    public int coins = 0;
    Quest quest;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnGUI() {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;

    }

    public void AddRandomCoins(int min, int max)
    {
        int randomAmount = Random.Range(min, max + 1); // +1 agar nilai max termasuk
        ChangeCoins(randomAmount);

        Debug.Log($"Player received {randomAmount} coins! Total coins: {coins}");
    }
}
