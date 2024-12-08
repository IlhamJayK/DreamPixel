using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NPC : MonoBehaviour
{
    public Quest quest;
    public Quest quest2;
    public Quest quest3;
    public GameObject E;
    Animator animator;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    
    public string[] startQuestDial;
    public string[] startQuestDial2;
    public string[] startQuestDial3;
    public string[] isFinishedDial;

    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public bool playerIsClose;

    public float walkSpeed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;

    bool isDialogueActive;

    public bool startQuest; 
    public bool startQuest2; 
    public bool startQuest3; 
    public bool isFinished; 

    void Awake()
    {
        dialogueText.text = "";
        animator = GetComponent<Animator>();
    }
    
    public bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                Vector3 currentScale = transform.localScale;
                currentScale.x *= -1; 
                transform.localScale = currentScale;
            }
            _isFacingRight = value;
        }
    }
    
    void Update()
    {
        Vector2 targetPosition = patrolPoints[currentPointIndex].position;

        if (targetPosition.x > transform.position.x && !_isFacingRight)
        {
            IsFacingRight = true;
        }
        else if (targetPosition.x < transform.position.x && _isFacingRight)
        {
            IsFacingRight = false;
        }

        if (transform.position != (Vector3)targetPosition && !isDialogueActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            if (!once)
            {
                once = true;
                StartCoroutine(Wait());
            }
            animator.SetBool("IsWalking", false);
        }

        if (quest.goal != null && quest.goal.IsReached() && quest2.goal != null && quest2.goal.IsReached() && quest3.goal != null && quest3.goal.IsReached())
    
    {
        isFinished = true; 
        SetCurrentDialogue();
    }
        
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                quest.isActive = true;
                
                if (quest.isActive == true){
                    StartQuest();
                }

                if (quest.goal != null && quest.goal.IsReached())
        {
            StartQuest2();
        }
        
        if (quest2.goal != null && quest2.goal.IsReached())
        {
            StartQuest3();
        }

                isDialogueActive = true;
                animator.SetBool("IsWalking", false);
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy || !playerIsClose)
        {
            RemoveText();
            isDialogueActive = false;
        }
    }

    void StartQuest (){
        startQuest = true;
        SetCurrentDialogue();
    }
    void StartQuest2 (){
        quest.isActive = false;
        quest2.isActive = true;
        startQuest = false;
        startQuest2 = true;
        SetCurrentDialogue();
    }
    void StartQuest3 (){
        quest2.isActive = false;
        quest3.isActive = true;
        startQuest = false;
        startQuest3 = true;
        startQuest2 = false;
        SetCurrentDialogue();
    }
    void IsFinished (){
        quest.isActive = false;
        quest2.isActive = false;
        quest3.isActive = false;
        
        startQuest = false;
        startQuest2 = false;
        startQuest3 = false;
        isFinished = true;
        SetCurrentDialogue();
    }

    public void SetCurrentDialogue()
{
    if (isFinished == true)
    {
        dialogue = isFinishedDial;
    }
    else if (startQuest == true)
    {
        dialogue = startQuestDial;
    }
    else if (startQuest2 == true)
    {
        dialogue = startQuestDial2;
    }
    else if (startQuest3 == true)
    {
        dialogue = startQuestDial3;
    }
}

public void LoadQuestStatus(PlayerData data)
{
    if (data.quest.Length > 0)
    {
        quest.isActive = data.quest[0];
        quest2.isActive = data.quest[1];
        quest3.isActive = data.quest[2];
        
        SetCurrentDialogue();
    }
}
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            E.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            E.SetActive(false);
            RemoveText();
        }
    }
}
