using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitRespawn : MonoBehaviour
{
    public GameObject treePrefab;
    public static FruitRespawn Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void RequestRespawn(Vector3 position)
    {
        StartCoroutine(RespawnCoroutine(position, 75f)); // 2 detik delay respawn
    }

    private IEnumerator RespawnCoroutine(Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject newTree = Instantiate(treePrefab, position, Quaternion.identity);
        Tree treeScript = newTree.GetComponent<Tree>();
        if (treeScript != null)
        {
            treeScript.Health = treeScript.Maxhealth;
            treeScript.IsAlive = true;
        }
    }
}
