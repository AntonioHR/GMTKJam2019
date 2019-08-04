using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "TowerDefense/Wave", order = 1)]

public class Wave : ScriptableObject
{
    public float initialDelay = 0f;
    public float timeBewteenSections = 5f;
    public ScriptableObject[] waveSections;
    
    public float TotalTime()
    {
        float totalTime = 0f;
        foreach (WaveSection ws in waveSections)
        {
            totalTime += ws.TotalTime;
        }
        return totalTime + timeBewteenSections;   
    }
}
