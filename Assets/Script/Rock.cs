using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int value;
    
    private RockManager coinManager;

    private void Start() {
        coinManager = RockManager.instance;
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
