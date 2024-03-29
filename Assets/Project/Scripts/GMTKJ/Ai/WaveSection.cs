﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSection", menuName = "TowerDefense/WaveSection", order = 1)]

public class WaveSection : ScriptableObject
{
    public float timeBewteenEnemies = 3f;
    public GameObject[] enemyPrefabs;

    public int Size { get { return enemyPrefabs.Length; } }
    public float TotalTime { get { return enemyPrefabs.Length * timeBewteenEnemies; } }
}
