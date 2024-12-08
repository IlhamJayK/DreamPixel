using UnityEngine;
using TMPro;

public class QuestLog : MonoBehaviour
{
    public NPC quest;

    public GameObject questWindow;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI reward;

    public void OpenQuestWindow(Quest activeQuest)
    {
        if (activeQuest != null)
        {
            title.text = activeQuest.title;
            description.text = activeQuest.description;
            reward.text = activeQuest.reward.ToString();
            Debug.Log("Opened Quest Window for: " + activeQuest.title);
        }
    }

    private void Update()
    {
        if (quest.quest != null && quest.quest.isActive)
        {
            OpenQuestWindow(quest.quest);
        }
        else if (quest.quest2 != null && quest.quest2.isActive)
        {
            OpenQuestWindow(quest.quest2);
        }
        else if (quest.quest3 != null && quest.quest3.isActive)
        {
            OpenQuestWindow(quest.quest3);
        }
        else
        {
            Debug.Log("No active quest to display.");
        }
    }
}
