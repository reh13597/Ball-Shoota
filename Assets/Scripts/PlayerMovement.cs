﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider col;

    //public bool allowButtonHold;
    //bool walking;

    public float moveSpeed = 12f;
    public float jumpForce = 10f;

    public LayerMask Ground;
    public AudioSource audioSource;
    private AudioClip walkingSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        walkingSound = Resources.Load<AudioClip>("footstep");
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

       // MyInput();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.D))))
        {
            audioSource.PlayOneShot(walkingSound);
            // Add code to make the sound keep playing when W or any forward/movement is triggered.
        }

        Vector3 move = transform.right * x + transform.forward * y;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    //private void MyInput()
    //{
    //    if (allowButtonHold)
    //    {
    //        walking = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    //    }
    //    else
    //    {
    //       walking = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));
    //    }
    
    //    if (walking == true)
    //    {
    //        audioSource.PlayOneShot(walkingSound);
    //   }
    //}


    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 9f, Ground);
    }
}