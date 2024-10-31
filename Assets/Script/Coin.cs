using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    
    private CoinManager coinManager;

    private void Start() {
        coinManager = CoinManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            
            coinManager.ChangeCoins(value);
            // Hancurkan item setelah dikumpulkan
            Destroy(gameObject);
        }
    }
}
