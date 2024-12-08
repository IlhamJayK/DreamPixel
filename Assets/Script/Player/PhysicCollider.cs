using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicCollider : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 moveDirection;

    private void Update()
    {
        // Input untuk pergerakan (WASD/Arrow keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Pergerakan manual menggunakan Translate
        if (moveDirection.magnitude > 0)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reset movement jika bertabrakan dengan invisible wall
            moveDirection = Vector3.zero;
        }
    }
}
