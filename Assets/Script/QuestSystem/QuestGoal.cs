using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public CoinManager coinManager;

    public GoalType goalType;

    public int requireAmount;
    public int currentAmount;

    public bool IsReached()
{
    // Sinkronkan currentAmount hanya untuk GoalType.Gathering
    if (goalType == GoalType.Gathering)
    {
        currentAmount = coinManager.coins;
    }
    else if (goalType == GoalType.Building)
    {
        currentAmount = BuildingManager.instance.activeBuildings;
    }
    else if (goalType == GoalType.Recruiting)
    {
        currentAmount = RecruitManager.instance.recruitedNPCs;
    }

    return currentAmount >= requireAmount;
}

}

public enum GoalType {
    Gathering, Building, Recruiting
}
