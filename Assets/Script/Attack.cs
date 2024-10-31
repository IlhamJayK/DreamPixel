using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider2D attackCollider;
    public int attackDamage = 1;

    private void Awake() {
        attackCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    
        Tree tree = collision.GetComponent<Tree>();
        if (tree != null){
            
            tree.Hit(attackDamage);
            Debug.Log(collision.name + " hit for "+ attackDamage);
        }
    }
    }

