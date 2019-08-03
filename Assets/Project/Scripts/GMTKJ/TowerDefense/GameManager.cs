using System;
using System.Collections;
using System.Collections.Generic;
using GMTKJ.TowerDefense;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get; private set; }

        public IngameScene ActiveScene{ get { return activeScene; } }
        
        private IngameScene activeScene;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
        }

        internal void OnSceneStarted(IngameScene scene)
        {
            activeScene = scene;
        }
    }
}