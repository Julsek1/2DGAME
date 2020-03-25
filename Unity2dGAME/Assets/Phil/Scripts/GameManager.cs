using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<int> fewestDeaths = new List<int>();
    public static List<float> fastestTime = new List<float>();

    public static List<int> totalDeaths = new List<int>();
    public static List<float> totalTime = new List<float>();

    private int currentLevelIndex;
    private int currentLevelDeaths;
    private float currentLevelTime;

    LevelLoader levelLoader;
    
    //Timer
    public Text timerTxt;
    private bool timerOn;

    //Victory


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;

        currentLevelIndex = 0;
        currentLevelDeaths = 0;
        currentLevelTime = 0f;

        totalDeaths.Add(40);
        fewestDeaths.Add(10);
        totalTime.Add(412.88f);
        fastestTime.Add(12.52f);

        totalDeaths.Add(500);
        fewestDeaths.Add(9);
        totalTime.Add(599f);
        fastestTime.Add(2.45f);
    }

    private void Update()
    {
        if (timerTxt && timerOn)
        {
            currentLevelTime += Time.deltaTime;
            timerTxt.text = TimeSpan.FromSeconds(currentLevelTime).ToString(@"mm\:ss\.ff");
        }
    }
    public void Death()
    {
        this.currentLevelDeaths++;
        LevelLoader.instance.Invoke("ReloadCurrentScene", 1);
    }

    public void PassedLevel()
    {
        timerOn = false;
        Goal.instance.DisplayVictoryScreen();
        //LevelLoader.instance.Load(++currentLevelIndex);
    }

    public int GetCurrentLevelDeaths()
    {
        return currentLevelDeaths;
    }

    public float GetCurrentLevelTime()
    {
        return currentLevelTime;
    }
}
