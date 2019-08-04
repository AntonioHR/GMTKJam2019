﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "TowerDefense/Wave", order = 1)]

public class Wave : ScriptableObject
{
    public ScriptableObject[] waveSections;
}
