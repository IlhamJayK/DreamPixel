using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    public GameObject house;
    public GameObject B;
    bool playerIsClose;

   void Update()
{
    if (playerIsClose == true && Input.GetKeyDown(KeyCode.B))
    {
        if (CoinManager.instance.coins >= 20 && RockManager.instance.coins >= 15)
        {
            CoinManager.instance.coins -= 20;
            RockManager.instance.coins -= 15;

            house.SetActive(true);
            AudioManagers.Instance.PlaySFX("Rebuild");
            BuildingManager.instance.IncrementBuildings(gameObject);
        }
        else
        {
            Debug.Log("Kayu dan batu tidak mencukupi");
        }
    }
}

private IEnumerator DestroyAfterFrame()
{
    yield return null; // Tunggu hingga frame berikutnya
    Destroy(gameObject);
}


     private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        playerIsClose = true;
        B.SetActive(true);
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        playerIsClose = false;
        B.SetActive(false);
    }
}
}
