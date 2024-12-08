using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int _rock;
    public int _wood;
    public int _fruit;
    public float[] position;
    public bool[] quest;
    public string sceneName;
    public int characterIndex;

    public PlayerData (PlayerManager player, CoinManager wood, RockManager rock, FruitTreeManager fruit, NPC npc){

        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        
        _wood = wood.coins;
        _rock = rock.coins;
        _fruit = fruit.coins;

        quest = new bool[3];
        quest[0] = npc.quest != null && npc.quest.isActive;
        quest[1] = npc.quest2 != null && npc.quest2.isActive;
        quest[2] = npc.quest3 != null && npc.quest3.isActive;

        sceneName = SceneManager.GetActiveScene().name;
    }
}
