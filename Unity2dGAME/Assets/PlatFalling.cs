using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFalling : MonoBehaviour
{

    Rigidbody2D rigBod;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 2f);
        }
    }

    void DropPlatform()
    {
        rigBod.isKinematic = false;
    }
}
