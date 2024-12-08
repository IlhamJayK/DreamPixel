using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcU : MonoBehaviour
{
    Animator animator;


    public float walkSpeed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;

    
    void Awake()
    {

    animator = GetComponent<Animator>();

    }
    
    public bool _isFacingRight = true;

    public bool IsFacingRight { get {
        return _isFacingRight;

    } private set{
        if (_isFacingRight != value) {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1; 
            transform.localScale = currentScale;
        }

        _isFacingRight = value;

    } }
    
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

    if (transform.position != (Vector3)targetPosition)
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

}


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length){
        currentPointIndex++;
        }
        else{
            currentPointIndex = 0;
        }
        once = false;
    }
}
