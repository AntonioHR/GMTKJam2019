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

        public void Start()
        {
            GameManager.Instance.OnSceneStarted(this);
        }
    }
}