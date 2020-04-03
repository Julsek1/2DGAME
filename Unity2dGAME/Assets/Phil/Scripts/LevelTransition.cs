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
                //panel.gameObject.transform.localScale = new Vector3(lifetime * 4, lifetime * 4);//shrink in
                panel.gameObject.transform.localScale = new Vector3(-120 * lifetime + 122, -120 * lifetime + 122);
            }
        }

        //if (countDown)
        //{
        //    lifetime -= Time.unscaledDeltaTime;

        //    if (lifetime <= 0)
        //    {
        //        countDown = false;
        //        panel.SetActive(false);
        //        player.EnableControls();

        //    }

        //    else
        //    {
        //        panel.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, lifetime);
        //    }
        //}
    }
}
