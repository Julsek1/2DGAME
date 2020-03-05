using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public ParticleSystem dust;

    [SerializeField] Sprite[] testSprites;
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

    //Cube
    bool wantsToTransform;
    bool isCube;

    //Wall
    bool isOnWall;
    int wallJumpDirection;

    //Animation
    Animator anim;

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
        isCube = false;
        wantsToTransform = false;
        anim = GetComponent<Animator>();
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

        if (controls.Player.Jump.triggered && !isCube)
        {
            isJumping = (numberOfJumps > 0);
        }

        if (controls.Player.Cube.triggered)
        {
            wantsToTransform = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            Jump();
        }

        if (wantsToTransform)
        {
            TransformToCube();
        }

        //    ////better jump?
        //    //if (rb.velocity.y < 0 && !Input.GetButton("Jump"))
        //    //{
        //    //    rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        //    //}
    }

    private void TransformToCube()
    {
        wantsToTransform = false;
        isCube = !isCube;
        //increase weight
        if (isCube)
        {
            //GetComponent<SpriteRenderer>().sprite = testSprites[1];
            rb.velocity = Vector2.zero;
            rb.gravityScale = 2;
            anim.SetBool("isCube", true);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.05f);
        }

        else
        {
            //GetComponent<SpriteRenderer>().sprite = testSprites[0];
            rb.gravityScale = 1;
            anim.SetBool("isCube", false);
            GetComponent<BoxCollider2D>().offset = Vector2.zero;
        }
        //no damage (except spikes)
    }

    private void Move()
    {
        if (!isCube)
        {
            float movement = controls.Player.Move.ReadValue<float>();

            anim.SetBool("isWalking", movement != 0);

            //float movement = Input.GetAxis("Horizontal");
            if (movement != 0)
            {
                GetComponent<SpriteRenderer>().flipX = (movement < 0);
                CreateDust();
            }

            //if (isJumping)
            //{
            //    rb.velocity = new Vector2(movement * moveSpeed / 2, rb.velocity.y);
            //}

            //else
            //{
                rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
            //}
        }
    }

    public void Jump()
    {
        //isJumping = (numberOfJumps > 0);

        if (isJumping)
        {
            anim.SetBool((numberOfJumps==2)?"isJumping":"isDoubleJumping", true);

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
            CreateDust();
            //}
        }

    }

    public void RestoreJumps()
    {
        numberOfJumps = maxJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //spikes

        if (collision.tag == "spikes")
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


        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            RestoreJumps();
            anim.SetBool("isJumping", false);
            anim.SetBool("isDoubleJumping", false);

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            isOnWall = false;
        }

        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }

    //dust ps

    void CreateDust()
    {
        dust.Play();
    }



}
