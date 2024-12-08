using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{   
    private FruitTreeManager coinManager;

    private void Start() {
        coinManager = FruitTreeManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            Debug.Log("player hit collider");
            coinManager.AddRandomCoins(2, 3);
            Destroy(gameObject);
        }
    }
    
}

