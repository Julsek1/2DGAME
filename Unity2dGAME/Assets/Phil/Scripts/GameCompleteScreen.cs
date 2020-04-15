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
                    world1Times.text += $"Level {i + 1}: {TimeSpan.FromSeconds(GameManager.totalTime[i]).ToString(GetTimeFormat(GameManager.totalTime[i]))}\n\n";
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
                    world2Times.text += $"Level {i - 4}: {TimeSpan.FromSeconds(GameManager.totalTime[i]).ToString(GetTimeFormat(GameManager.totalTime[i]))}\n\n";
                }

                else
                {
                    world2Times.text += $"Level {i - 4}: NA\n\n";
                }
            }
        }

        //world1Times.text = $"Level 1: {TimeSpan.FromSeconds(GameManager.totalTime[0]).ToString(GetTimeFormat(GameManager.totalTime[0]))}\n\n" +
        //                   $"Level 2: {TimeSpan.FromSeconds(GameManager.totalTime[1]).ToString(GetTimeFormat(GameManager.totalTime[1]))}\n\n" +
        //                   $"Level 3: {TimeSpan.FromSeconds(GameManager.totalTime[2]).ToString(GetTimeFormat(GameManager.totalTime[2]))}\n\n" +
        //                   $"Level 4: {TimeSpan.FromSeconds(GameManager.totalTime[3]).ToString(GetTimeFormat(GameManager.totalTime[3]))}\n\n" +
        //                   $"Level 5: {TimeSpan.FromSeconds(GameManager.totalTime[4]).ToString(GetTimeFormat(GameManager.totalTime[4]))}";

        //world2Times.text = $"Level 1: {TimeSpan.FromSeconds(GameManager.totalTime[5]).ToString(GetTimeFormat(GameManager.totalTime[5]))}\n\n" +
        //                   $"Level 2: {TimeSpan.FromSeconds(GameManager.totalTime[6]).ToString(GetTimeFormat(GameManager.totalTime[6]))}\n\n" +
        //                   $"Level 3: { TimeSpan.FromSeconds(GameManager.totalTime[7]).ToString(GetTimeFormat(GameManager.totalTime[7]))}\n\n" +
        //                   $"Level 4: {TimeSpan.FromSeconds(GameManager.totalTime[8]).ToString(GetTimeFormat(GameManager.totalTime[8]))}\n\n" +
        //                   $"Level 5: {TimeSpan.FromSeconds(GameManager.totalTime[9]).ToString(GetTimeFormat(GameManager.totalTime[9]))}";

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
