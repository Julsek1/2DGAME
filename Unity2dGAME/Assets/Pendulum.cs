using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    
    public Rigidbody2D rigidB2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;


    void Start()
    {
        rigidB2d = GetComponent<Rigidbody2D>();
        rigidB2d.angularVelocity = velocityThreshold;
    }

    
    void Update()
    {

        Push(); 
    }

    public void Push()
    {
        if(transform.rotation.z > 0
            && transform.rotation.z < rightPushRange
            && (rigidB2d.angularVelocity > 0)
            && rigidB2d.angularVelocity < velocityThreshold)
         
        {
            rigidB2d.angularVelocity = velocityThreshold;

        }
        else if(transform.rotation.z < 0
            && transform.rotation.z > leftPushRange
            && (rigidB2d.angularVelocity < 0)
            && rigidB2d.angularVelocity > velocityThreshold* -1)
        {
            rigidB2d.angularVelocity = velocityThreshold* -1;

        }
    }
}
