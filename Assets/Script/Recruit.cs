using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruit : MonoBehaviour
{
    public GameObject R;
    public GameObject[] Npcs;
    public Transform[] newPatrolPoint1;
    public Transform[] newPatrolPoint2;
    public Transform[] newPatrolPoint3;

    private List<Transform[]> newPatrolPoints;
    private bool playerIsClose = false;

    private void Start()
    {
        newPatrolPoints = new List<Transform[]> { newPatrolPoint1, newPatrolPoint2, newPatrolPoint3 };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerIsClose)
        {
            RecruitNpcs();
        }
    }

    private void RecruitNpcs()
    {
        if (FruitTreeManager.instance.coins >= 15)
        {
            FruitTreeManager.instance.coins -= 15;

            RecruitManager.instance.RecruitNPC();
            
            for (int i = 0; i < Npcs.Length; i++)
            {
                if (i < newPatrolPoints.Count && Npcs[i] != null)
                {
                    npcU npcScript = Npcs[i].GetComponent<npcU>();
                    if (npcScript != null)
                    {
                        npcScript.patrolPoints = newPatrolPoints[i];
                    }
                }
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            R.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            R.SetActive(false);
        }
    }
}
