using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Movement player;
    float lifetime;
    bool countDown;
    private void Start()
    {
        lifetime = 1f;
        countDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        //lifetime -= Time.deltaTime;

        if (countDown)
        {
            lifetime -= Time.unscaledDeltaTime;

            if (lifetime <= 0)
            {
                countDown = false;
                panel.SetActive(false);
                player.EnableControls();

            }

            else
            {
                panel.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, lifetime);
            }
        }
    }
}
