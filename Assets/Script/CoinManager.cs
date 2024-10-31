using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{   
    public static CoinManager instance;
    public TMP_Text coinsDisplay;
    public int coins = 0;

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
    }

    private void OnGUI() {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount){
        coins += amount;
    }

}
