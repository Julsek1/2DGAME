using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static List<int> fewestDeaths = new List<int>();
    public static List<float> fastestTime = new List<float>();

    public static List<int> totalDeaths = new List<int>();
    public static List<float> totalTime = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        totalDeaths.Add(40);
        fewestDeaths.Add(10);
        totalTime.Add(412.88f);
        fastestTime.Add(12.52f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
