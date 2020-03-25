using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Text deathStats;
    [SerializeField] Text timeStats;
    [SerializeField] Image levelImage;
    [SerializeField] Sprite[] worldImages;

    const float ANIMATION_SPEED = 0.25f;
    float animationSpeed;
    int spriteIndex;
    int levelIndex;

    //stats
    string time;

    Controls controls;
    private void Awake()
    {
        controls = new Controls();
    }
    // Start is called before the first frame update
    void Start()
    {
        controls.Menu.Enable();
        transform.position = buttons[0].transform.position;
        GetComponent<Image>().sprite = sprites[0];
        animationSpeed = ANIMATION_SPEED;
        spriteIndex = 0;
        levelIndex = 0;
        deathStats.text = "";
        timeStats.text = "";
        levelImage.gameObject.SetActive(false);
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
            buttons[levelIndex].onClick.Invoke();
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
                    transform.position = buttons[--levelIndex].transform.position;
                }
            }

            else if (direction > 0)
            {
                if (levelIndex != buttons.Length - 1)
                {
                    transform.position = buttons[++levelIndex].transform.position;
                }
            }

            if (levelIndex > 0 && levelIndex < buttons.Length - 1)
            {
                try
                {
                    deathStats.text = $"Total deaths: {GameManager.totalDeaths[levelIndex - 1]}	"+	
                                      $"\n\nFewest deaths: {GameManager.fewestDeaths[levelIndex - 1]}";    
                    
                    timeStats.text = $"Total Time: {TimeSpan.FromSeconds(GameManager.totalTime[levelIndex - 1]).ToString(GetTimeFormat(GameManager.totalTime[levelIndex - 1]))}" +
                                     $"\n\nFastest Time: {TimeSpan.FromSeconds(GameManager.fastestTime[levelIndex - 1]).ToString(GetTimeFormat(GameManager.fastestTime[levelIndex - 1]))}";

                    levelImage.gameObject.SetActive(true);
                    levelImage.sprite = worldImages[levelIndex - 1];

                }
                catch
                {
                    deathStats.text = $"Total deaths: 0" +
                                      $"\n\nFewest deaths: 0";
                    timeStats.text = "Total Time: 0" +
                                     $"\n\nFastest Time: 0";
                    levelImage.gameObject.SetActive(false);
                }
            }

            else
            {
                deathStats.text = "";
                timeStats.text = "";
                levelImage.gameObject.SetActive(false);
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

    private string GetTimeFormat(float time)
    {
        if (time >= 36000)
        {
            return @"hh\:mm\:ss\.ff";
        }

        else if (time < 36000 && time >= 3600)
        {
            return @"h\:mm\:ss\.ff";
        }

        else if (time >= 600)
        {
            return @"mm\:ss\.ff";
        }

        else if (time < 600 && time >= 60)
        {
            return @"m\:ss\.ff";
        }

        else if (time >= 10)
        {
            return @"ss\.ff";
        }

        return @"s\.ff";
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
