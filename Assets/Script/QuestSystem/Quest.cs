using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string title;
    public string description;
    public int reward;

    public QuestGoal goal;
}
