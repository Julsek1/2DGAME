using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;

    public static Goal instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void DisplayVictoryScreen()
    {
        victoryScreen.gameObject.SetActive(true);
    }
}
