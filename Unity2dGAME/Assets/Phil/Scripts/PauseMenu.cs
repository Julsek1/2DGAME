using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button resume;

    private void OnEnable()
    {
        SetSelectedButton();
    }

    private void SetSelectedButton()
    {
        resume.Select();
        resume.OnSelect(null);
    }
}
