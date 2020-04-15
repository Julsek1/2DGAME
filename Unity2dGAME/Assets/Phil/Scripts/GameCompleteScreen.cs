using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompleteScreen : MonoBehaviour
{
    [SerializeField] Text world1Times;
    [SerializeField] Text world2Times;

    private void Start()
    {
        world1Times.text = "";
        world2Times.text = "";

        for (int i = 0; i < 10; i++)
        {
            if (i < 5)
            {
                if (GameManager.totalTime.ContainsKey(i))
                {
                    world1Times.text += $"Level {i + 1}: {TimeSpan.FromSeconds(GameManager.fastestTime[i]).ToString(GetTimeFormat(GameManager.fastestTime[i]))}\n\n";
                }

                else
                {
                    world1Times.text += $"Level {i + 1}: NA\n\n";
                }
            }

            else
            {
                if (GameManager.totalTime.ContainsKey(i))
                {
                    world2Times.text += $"Level {i - 4}: {TimeSpan.FromSeconds(GameManager.fastestTime[i]).ToString(GetTimeFormat(GameManager.fastestTime[i]))}\n\n";
                }

                else
                {
                    world2Times.text += $"Level {i - 4}: NA\n\n";
                }
            }
        }
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
}
