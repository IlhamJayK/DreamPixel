using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float walkspeed = 5f;
    Rigidbody2D rb;

    Animator animator;

    Vector2 moveInput;

    private bool _isMoving = false;

    public bool IsMoving { get {
        
        return _isMoving;
    } private set{

       _isMoving = value;
       animator.SetBool("IsMoving", value);
    } }

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

    public bool CanMove {
        get {
            return animator.GetBool("canMove");
        }
    }
    public float Walkspeed {
    get { 
        if (CanMove) {
            return walkspeed;
        } else {
            return 0;
        }
    }
    }
    
    void Awake() {
    
    rb = GetComponent<Rigidbody2D>();    
    animator = GetComponent<Animator>();
    
    }
    
    void FixedUpdate() {

        if (CanMove) {
        rb.velocity = new Vector2(moveInput.x * Walkspeed, rb.velocity.y);
    } else {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    public void SetFacingDirection(Vector2 moveInput){

        if(moveInput.x > 0 && !IsFacingRight){
            IsFacingRight = true;

        }else if (moveInput.x < 0 && IsFacingRight ){
            IsFacingRight = false;

        }

    }

    public void OnAttack(InputAction.CallbackContext context)
{
    if (context.performed)
    {
        animator.SetTrigger("attack");
        animator.SetBool("canMove", false);
        AudioManagers.Instance.PlaySFX("Hit");
    }
}
}
