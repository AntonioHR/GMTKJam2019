using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{ 
    public class IngameScene : MonoBehaviour
    {
        public static IngameScene Current{get{return GameManager.Instance.ActiveScene; } }
        [SerializeField]
        private PlaneCursor cursor;

        public PlaneCursor Cursor
        {
            get
            {
                return cursor;
            }
        }

        public void Start()
        {
            GameManager.Instance.OnSceneStarted(this);
        }
    }
}