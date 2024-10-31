using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Animator animator;
    public GameObject logPrefab;

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
                
                // Instantiate logPrefab di posisi yang telah diatur
                Vector3 logPosition = transform.position + Vector3.up * 5;
                Instantiate(logPrefab,transform.position, transform.rotation);
               
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

    // Method untuk memicu animasi shake
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
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject!");
        }
    }

    private void Update()
    {
        // Kosong sementara
    }

    // Method ketika pohon menerima damage
    public void Hit(int damage)
    {
        if (IsAlive)
        {
            Shake(); // Memicu animasi shake
            Health -= damage; // Mengurangi health pohon
        }
    }
}
