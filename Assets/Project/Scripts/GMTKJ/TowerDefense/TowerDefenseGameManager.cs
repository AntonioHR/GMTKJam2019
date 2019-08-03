using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefenseGameManager : MonoBehaviour
{
    public TowerDefenseGameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

}
