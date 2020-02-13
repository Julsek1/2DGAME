using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Character
    Rigidbody2D rb;

    //Movement
    float MoveSpeed;

    //Jump
    bool isJumping;
    int numberOfJumps;
    int maxJumps;

    //Wall
    bool isOnWall;
    int wallJumpDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        MoveSpeed = 1.25f;
        maxJumps = 2;
        numberOfJumps = maxJumps;
        isOnWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        //visual indication of the number of jumps left
        if (numberOfJumps == 2)
        {
            this.GetComponent<SpriteRenderer>().color = Color.magenta;
        }

        else if (numberOfJumps == 1)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        Move();

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = (numberOfJumps > 0) ? true : false;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            Jump();
        }

        ////better jump?
        //if (rb.velocity.y < 0 && !Input.GetButton("Jump"))
        //{
        //    rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        //}
    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * MoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        //wall jump
        if (isOnWall)
        {
            isOnWall = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(150f * wallJumpDirection, 200f));
        }

        //normal jump
        else
        {
            numberOfJumps--;
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, 125f));
        }

    }

    public void RestoreJumps()
    {
        numberOfJumps = maxJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            RestoreJumps();
        }

        else if (collision.gameObject.name == "Wall")
        {
            isOnWall = true;

            if (numberOfJumps < 2)
            {
                numberOfJumps++;
            }

            wallJumpDirection = (this.transform.position.x > collision.transform.position.x) ? 1 : -1;
        }

        //else if(collision.gameObject.name == "Bouncer")
        //{
        //    rb.AddForce(new Vector2(0f, 200f));
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            isOnWall = false;
        }
    }
}
