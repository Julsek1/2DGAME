using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    BoxCollider2D col;
    Collider2D laserCol;
    AudioSource laserAudio;

   

    // Start is called before the first frame update
    void Start()
    {

        laserCol = this.GetComponent<Collider2D>();
        laserAudio = this.GetComponent<AudioSource>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollision()
    {
        laserCol.enabled = true;
        laserAudio.Play();
    }

    public void OffCollision()
    {
        laserCol.enabled = false;
        
    }

}
