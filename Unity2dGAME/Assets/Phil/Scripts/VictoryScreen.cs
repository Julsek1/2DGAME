using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] Text stats;
    [SerializeField] Button next;
    private void OnEnable()
    {
        stats.text = $"Deaths: {GameManager.instance.GetCurrentLevelDeaths()}\n\n" +
                     $"Time: {TimeSpan.FromSeconds(GameManager.instance.GetCurrentLevelTime()).ToString(GetTimeFormat(GameManager.instance.GetCurrentLevelTime()))}";

        SetSelectedButton();
    }

    private void SetSelectedButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(next.gameObject);
        next.OnSelect(new BaseEventData(EventSystem.current));
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
