using System;
using DG.Tweening;
using GMTKJ.Ai;
using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{ 
    public class IngameScene : MonoBehaviour
    {
        [SerializeField]
        private float camZoomOut = 20;
        [SerializeField]
        private float camNormalView = 20;
        public static IngameScene Current{get{return GameManager.Instance.ActiveScene; } }
        [SerializeField]
        private PlaneCursor cursor;

        [SerializeField]
        private Transform bulletsFolder;
        [SerializeField]
        private CanvasGroup gameOver;
        [SerializeField]
        private CanvasGroup start;

        private WaveManager[] waveManagers;


        [SerializeField]
        private Nexus nexus;
        [SerializeField]
        private Player player;
        private bool begun;

        public PlaneCursor Cursor
        {
            get
            {
                return cursor;
            }
        }

        public Transform BulletsFolder { get => bulletsFolder;}
        public Player Player { get => player;}
        public Nexus Nexus {get=>nexus;}

        public void Start()
        {
            Camera.main.orthographicSize = camZoomOut;
            GameManager.Instance.OnSceneStarted(this);
            waveManagers = FindObjectsOfType<WaveManager>();
        }
        public void Update()
        {
            if(!begun && Input.GetKeyDown(KeyCode.Space))
            {
                Begin();
            }
        }
        public void Begin ()
        {
            begun = true;
            foreach(WaveManager mngr in waveManagers)
            {
                mngr.Begin();
            }
            Camera.main.DOOrthoSize(camNormalView, 1);
            start.interactable = false;
            start.DOFade(0, 1);
        }
        public void OnNexusDead(Nexus nexus)
        {
            gameOver.DOFade(1, 1);

            player.OnNexusDead();
        }
    }
}