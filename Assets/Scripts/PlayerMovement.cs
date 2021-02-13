using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider col;

    public float moveSpeed = 12f;
    public float jumpForce = 10f;

    public LayerMask Ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Hello");
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.D))))
        {
            Sounds.PlaySound("walk");
        }
            
        Vector3 move = transform.right * x + transform.forward * y;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 9f, Ground);
    }
}