﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - 0.01f, 0f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            //take velocity absolute and add it to the upward force
            collision.GetComponent<Movement>().RestoreJumps();
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50);
        }
    }
}
