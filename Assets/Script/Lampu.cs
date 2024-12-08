using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampu : MonoBehaviour
{
    private PlayerManager manager; 
    public Vector3 offset;         

    private void Start()
    {
        manager = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        if (manager != null && manager.player != null)
        {
            transform.position = manager.player.transform.position + offset;
        }
    }
}
