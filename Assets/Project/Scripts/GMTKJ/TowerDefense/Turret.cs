using System;
using GMTKJ.Bullets;
using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;
        private TwoPointMover mover;
        private RotateByMouse rot;
        private Shooter shooter;
        [SerializeField]
        private RotateByMouse.Settings rotationSettings;
        [SerializeField]
        private Transform shootingSpot;
        [SerializeField]
        private Transform selectIndicator;
        [SerializeField]
        private TwoPointMover.Setup setup;

        public bool IsManned{get; set;}

        public void Start()
        {
            mover = new TwoPointMover(transform, setup);
            rot = new RotateByMouse(IngameScene.Current.Cursor, transform, rotationSettings);
            shooter = new Shooter(bulletPrefab, shootingSpot, IngameScene.Current.BulletsFolder);
        }

        public void Update()
        {
            if(IsManned)
            {
                rot.Update();
                mover.Update();

                if(Input.GetMouseButtonDown(0))
                {
                    shooter.Fire(transform.forward);
                }
            }
        }

        public void OnDeselect()
        {
            selectIndicator.gameObject.SetActive(false);
        }

        public void OnSelect()
        {
            selectIndicator.gameObject.SetActive(true);
        }
    }
}