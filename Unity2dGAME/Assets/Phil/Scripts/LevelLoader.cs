﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] MainMenuCanvas mainMenuCanvas;
    public static LevelLoader instance;

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

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Load(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public int ReturnLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }
}
