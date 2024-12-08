using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public int activeBuildings;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void IncrementBuildings(GameObject objToDestroy)
{
    activeBuildings++; 
    Destroy(objToDestroy); 
}
}
