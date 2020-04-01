using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        LevelLoader.instance.LoadNext();
    }

    public void LoadMenu()
    {
        LevelLoader.instance.LoadMenu();
    }
}
