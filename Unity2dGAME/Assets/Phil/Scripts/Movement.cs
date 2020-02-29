using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //Character
    Rigidbody2D rb;

    //Controls
    Controls controls = null;

    //Movement
    [SerializeField] float moveSpeed;

    //Jump
    [SerializeField] float jumpHeight;
    bool isJumping;
    int numberOfJumps;
    int maxJumps;

    //Wall
    bool isOnWall;
    int wallJumpDirection;

   
    private void Awake()
    {
        controls = new Controls();
    }
    // Start is called before the first frame update
   
       
    
    void Start()
    {
        controls.Player.Enable();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        maxJumps = 2;
        numberOfJumps = maxJumps;
        isOnWall = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //visual indication of the number of jumps left
        //if (numberOfJumps == 2)
        //{
        //    this.GetComponent<SpriteRenderer>().color = Color.magenta;
        //}

        //else if (numberOfJumps == 1)
        //{
        //    this.GetComponent<SpriteRenderer>().color = Color.red;
        //}

        //else
        //{
        //    this.GetComponent<SpriteRenderer>().color = Color.blue;
        //}

        Move();

        if (controls.Player.Jump.triggered)
        {
            isJumping = (numberOfJumps > 0);
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            Jump();
        }

        //    ////better jump?
        //    //if (rb.velocity.y < 0 && !Input.GetButton("Jump"))
        //    //{
        //    //    rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        //    //}
    }

    private void Move()
    {
        float movement = controls.Player.Move.ReadValue<float>();
        //float movement = Input.GetAxis("Horizontal");
        if (movement != 0)
        {
            GetComponent<SpriteRenderer>().flipX = (movement < 0);
        }

        if (isJumping)
        {
            rb.velocity = new Vector2(movement * moveSpeed / 2, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        }

    }

    public void Jump()
    {
        //isJumping = (numberOfJumps > 0);

        if (isJumping)
        {
            ////wall jump
            //if (isOnWall)
            //{
            //    isOnWall = false;
            //    rb.velocity = Vector2.zero;
            //    rb.AddForce(new Vector2(150f * wallJumpDirection, 200f));
            //}

            //normal jump
            //else
            //{
            numberOfJumps--;
            isJumping = false;
            //rb.velocity = new Vector2(/*rb.velocity.x*/0f, 0f);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0f, jumpHeight));
            //}
            Debug.Log("Once");
        }

    }

    public void RestoreJumps()
    {
        numberOfJumps = maxJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //spikes

        if(collision.tag == "spikes")
        {
            //reload scene
            
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        // Laser trap

        if (collision.gameObject.name == "Laser Trap")
        {
            
            //reload scene
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


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

    //death function
   
}
