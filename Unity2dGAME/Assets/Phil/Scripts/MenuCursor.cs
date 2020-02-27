using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour
{
    [SerializeField] Button[] levels;
    [SerializeField] Sprite[] sprites;

    const float ANIMATION_SPEED = 0.25f;
    float animationSpeed;
    int spriteIndex;

    int levelIndex;

    Controls controls;
    private void Awake()
    {
        controls = new Controls();
    }
    // Start is called before the first frame update
    void Start()
    {
        controls.Menu.Enable();
        transform.position = levels[0].transform.position;
        GetComponent<Image>().sprite = sprites[0];
        animationSpeed = ANIMATION_SPEED;
        spriteIndex = 0;
        levelIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        Movement();
        Select();
    }


    private void Select()
    {
        if (controls.Menu.Accept.triggered)
        {
            levels[levelIndex].onClick.Invoke();
        }
    }

    private void Movement()
    {
        if (controls.Menu.Move.triggered)
        {
            float direction = controls.Menu.Move.ReadValue<float>();

            if (direction < 0)
            {
                if (levelIndex != 0)
                {
                    transform.position = levels[--levelIndex].transform.position;
                }
            }

            else if (direction > 0)
            {
                if (levelIndex != levels.Length - 1)
                {
                    transform.position = levels[++levelIndex].transform.position;
                }
            }
        }
        

        //if (Input.GetButtonDown("Left"))
        //{
        //    if (levelIndex != 0)
        //    {
        //        transform.position = levels[--levelIndex].transform.position;
        //    }
        //}

        //else if (Input.GetButtonDown("Right"))
        //{
        //    if (levelIndex != levels.Length - 1)
        //    {
        //        transform.position = levels[++levelIndex].transform.position;
        //    }
        //}
    }

    private void Animate()
    {
        animationSpeed -= Time.deltaTime;
        if (animationSpeed <= 0)
        {
            if (spriteIndex == sprites.Length)
            {
                spriteIndex = 0;
            }

            GetComponent<Image>().sprite = sprites[spriteIndex++];
            animationSpeed = ANIMATION_SPEED;
        }
    }
}
