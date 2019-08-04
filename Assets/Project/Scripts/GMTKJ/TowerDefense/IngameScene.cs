using System;
using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{ 
    public class IngameScene : MonoBehaviour
    {
        public static IngameScene Current{get{return GameManager.Instance.ActiveScene; } }
        [SerializeField]
        private PlaneCursor cursor;

        [SerializeField]
        private Transform bulletsFolder;


        [SerializeField]
        private Nexus nexus;
        [SerializeField]
        private Player player;

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
            GameManager.Instance.OnSceneStarted(this);
        }
        public void OnNexusDead(Nexus nexus)
        {
            player.OnNexusDead();
        }
    }
}