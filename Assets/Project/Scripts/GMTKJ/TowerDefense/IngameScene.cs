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

        public PlaneCursor Cursor
        {
            get
            {
                return cursor;
            }
        }

        public Transform BulletsFolder { get => bulletsFolder;}

        public void Start()
        {
            GameManager.Instance.OnSceneStarted(this);
        }
    }
}