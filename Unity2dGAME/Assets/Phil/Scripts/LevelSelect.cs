using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    string position;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = levels[0].gameObject.transform.position;
        position = levels[0].gameObject.name;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = levels[0].gameObject.transform.position;
            position = levels[0].gameObject.name;
        }

        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = levels[1].gameObject.transform.position;
            position = levels[1].gameObject.name;

        }

        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log(position);
        }
    }
}
