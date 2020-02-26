using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePanel(int index)
    {
        foreach (var p in panels)
        {
            p.SetActive(false);
        }

        panels[index].SetActive(true);
    }
}
