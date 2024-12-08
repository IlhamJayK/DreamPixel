using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitManager : MonoBehaviour
{
    public static RecruitManager instance;
    public int recruitedNPCs;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void RecruitNPC()
    {
        recruitedNPCs++;
    }
}
