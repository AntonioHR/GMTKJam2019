using GMTKJ.Bullets;
using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        private RotateByMouse rot;
        private Shooter shooter;
        [SerializeField]
        private RotateByMouse.Settings rotationSettings;
        [SerializeField]
        private Transform shootingSpot;

        public bool IsManned{get; set;} = true;

        public void Start()
        {
            rot = new RotateByMouse(IngameScene.Current.Cursor, transform, rotationSettings);
            shooter = new Shooter(bulletPrefab, shootingSpot, IngameScene.Current.BulletsFolder);
        }

        public void Update()
        {
            if(IsManned)
            {

                rot.Update();
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    shooter.Fire(transform.forward);
                }
            }
        }
    }
}