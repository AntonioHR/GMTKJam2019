﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixateRotation : MonoBehaviour
{
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
