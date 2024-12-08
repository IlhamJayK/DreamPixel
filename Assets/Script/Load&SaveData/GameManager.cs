using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public CoinManager coinManager;
    public RockManager rockManager;
    public FruitTreeManager fruitManager;
    public NPC npc;

    public void SaveGame()
    {
        SaveSystem.SavePlayer(playerManager, coinManager, rockManager, fruitManager, npc);
        Debug.Log("Game saved successfully!");
    }

    public void LoadGame()
{
    PlayerData data = SaveSystem.LoadPlayer();
    
    if (data != null)
    {
        // Muat scene terlebih dahulu
        if (SceneManager.GetActiveScene().name != data.sceneName)
        {
            SceneManager.LoadScene(data.sceneName);
        }

        // Tunggu hingga scene selesai dimuat sebelum menerapkan data pemain
        StartCoroutine(LoadGameAfterScene(data));
    }
    else
    {
        Debug.Log("No save data found.");
    }
}

private IEnumerator LoadGameAfterScene(PlayerData data)
{
    // Tunggu hingga scene selesai dimuat
    yield return new WaitUntil(() => SceneManager.GetActiveScene().name == data.sceneName);

    // Terapkan posisi pemain
    playerManager.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

    // Terapkan data lainnya
    coinManager.coins = data._wood;
    rockManager.coins = data._rock;
    fruitManager.coins = data._fruit;

    npc.LoadQuestStatus(data);

    Debug.Log("Game loaded successfully!");
}
}

