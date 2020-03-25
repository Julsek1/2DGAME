using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public Dictionary<int, int> fewestDeaths;
    public Dictionary<int, float> fastestTime;
    public Dictionary<int, int> totalDeaths;
    public Dictionary<int, float> totalTime;

    public LevelData(Dictionary<int, int> fewestDeaths, Dictionary<int, float> fastestTime, Dictionary<int, int> totalDeaths, Dictionary<int, float> totalTime)
    {
        this.fewestDeaths = fewestDeaths;
        this.fastestTime = fastestTime;
        this.totalDeaths = totalDeaths;
        this.totalTime = totalTime;
    }
}
