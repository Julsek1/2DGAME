using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour
{

    public float rotationSpeed;

    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, rotationSpeed)); 
    }
}
