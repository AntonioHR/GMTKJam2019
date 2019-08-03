using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        private RotateByMouse rot;
        [SerializeField]
        private RotateByMouse.Settings rotationSettings;

        public void Start()
        {
            rot = new RotateByMouse(IngameScene.Current.Cursor, transform, rotationSettings);
        }

        public void Update()
        {
            rot.Update();
        }
    }
}