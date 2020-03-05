using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] panels;

    public void EnablePanel(int index)
    {
        foreach (var p in panels)
        {
            p.SetActive(false);
        }

        panels[index].SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }
}
