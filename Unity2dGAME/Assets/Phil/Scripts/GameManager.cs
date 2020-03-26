using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<int, int> fewestDeaths = new Dictionary<int, int>();
    public static Dictionary<int, float> fastestTime = new Dictionary<int, float>();
    public static Dictionary<int, int> totalDeaths = new Dictionary<int, int>();
    public static Dictionary<int, float> totalTime = new Dictionary<int, float>();

    LevelData data;

    //private int currentLevelIndex;
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
        if (SaveSystem.LoadData() != null)
        {
            LoadData();
        }

        else
        {
            data = new LevelData(fewestDeaths, fastestTime, totalDeaths, totalTime);
        }

        //currentLevelIndex = 0;
        currentLevelDeaths = 0;
        currentLevelTime = 0f;

        //totalDeaths.Add(40);
        //fewestDeaths.Add(10);
        //totalTime.Add(412.88f);
        //fastestTime.Add(12.52f);

        //totalDeaths.Add(500);
        //fewestDeaths.Add(9);
        //totalTime.Add(599f);
        //fastestTime.Add(2.45f);
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

    public void PassedLevel(int index)
    {
        timerOn = false;

        try
        {
            totalDeaths[index] += currentLevelDeaths;
            totalTime[index] += currentLevelTime;

            if (currentLevelDeaths < fewestDeaths[index])
            {
                fewestDeaths[index] = currentLevelDeaths;
            }

            if (currentLevelTime < fastestTime[index])
            {
                fastestTime[index] = currentLevelTime;
            }
        }

        catch
        {
            totalDeaths.Add(index, currentLevelDeaths);
            totalTime.Add(index, currentLevelTime);
            fewestDeaths.Add(index, currentLevelDeaths);
            fastestTime.Add(index, currentLevelTime);
        }
        

        SaveData();
        //LevelLoader.instance.Load(++currentLevelIndex);
        Goal.instance.DisplayVictoryScreen();

    }

    public int GetCurrentLevelDeaths()
    {
        return currentLevelDeaths;
    }

    public float GetCurrentLevelTime()
    {
        return currentLevelTime;
    }

    public void StartTimer()
    {
        currentLevelTime = 0f;
        timerOn = true;
    }

    public void SaveData()
    {
        data.fewestDeaths = fewestDeaths;
        data.fastestTime = fastestTime;
        data.totalDeaths = totalDeaths;
        data.totalTime = totalTime;
        SaveSystem.SaveData(data);
    }

    public void LoadData()
    {
        data = SaveSystem.LoadData();
        fewestDeaths = data.fewestDeaths;
        fastestTime = data.fastestTime;
        totalDeaths = data.totalDeaths;
        totalTime = data.totalTime;
    }
}
