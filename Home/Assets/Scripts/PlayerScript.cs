﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 5f;
    [SerializeField]
    private float jumpForce = 110f;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private float playerGravity = 50f;
    [SerializeField]
    private Transform child;
    [SerializeField]
    GameObject player;
    //[SerializeField]
    //Vector3 position;
    [SerializeField]
    int decapitateTimer = 0;

    private Rigidbody2D playerRigidbody;
    //private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        //position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        float horizontal = Input.GetAxis("Horizontal");

        IsGrounded();

        Movement( horizontal );

        Jump();

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (child)
            {
                decapitateTimer = 0;
                child.transform.parent = null;
                Jump();
                Debug.Log("De-parenting head from body.");
                child = null;
            }
        }

        decapitateTimer++;
    }

    private void Movement(float horizontal)
    {
        playerRigidbody.velocity = new Vector2(horizontal *playerSpeed, playerRigidbody.velocity.y);
        //position += move * playerSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJumping == false)
            {
                playerRigidbody.AddForce( Vector2.up * jumpForce, ForceMode2D.Impulse );
            }
        }
    }

    private void IsGrounded()
    {
        if(playerRigidbody.velocity.y == 0)
        {
            isJumping = false;
        }
        else
        {
            Physics.gravity = new Vector3(0, -1, 0) * playerGravity;
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (decapitateTimer > 120)
        {
            if (collision.gameObject.tag == "Body")
            {
                if (child == null)
                {
                    Debug.Log("Head has been parented to body.");
                    collision.transform.parent = this.transform;
                    // collision.rigidbody.isKinematic = false;
                    child = collision.transform;
                }
            }
        }
    }
}
