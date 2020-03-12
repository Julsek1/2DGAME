using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkTimer : MonoBehaviour
{
    [SerializeField] Text timerText;
    private void Awake()
    {
        GameManager.instance.timerTxt = timerText;
    }
}
