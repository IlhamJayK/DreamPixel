using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : MonoBehaviour
{
    Animator animator;
    public GameObject logPrefab;
    public GameObject fruitPrefab;

    [SerializeField]
    private int _maxHealth = 10;

    public int Maxhealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    [SerializeField]
    private int _health = 10;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
                
                Instantiate(logPrefab,transform.position, transform.rotation);
                Instantiate(fruitPrefab,transform.position, transform.rotation);

                AudioManagers.Instance.PlaySFX("Destroy");
               
            }
        }
    }

    private bool _isAlive = true;

    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            animator.SetBool("IsAlive", value);
            Debug.Log("IsAlive set to " + value);
        }
    }


    public void Shake()
    {
        if (animator != null)
        {
            animator.SetTrigger("Shake");
        }
        else
        {
            Debug.LogError("Animator is not assigned!");
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Hit(int damage)
    {
        if (IsAlive)
        {
            Shake(); 
            Health -= damage; 
        }
    }
}
