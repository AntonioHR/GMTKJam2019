using System;
using System.Collections;
using GMTKJ.Bullets;
using GMTKJ.Movement;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;
        [SerializeField]
        private float fireDelay;
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
            StartCoroutine(AutoFire(fireDelay));
        }

        private IEnumerator AutoFire(float fireDelay)
        {
            while(true)
            {
                yield return new WaitForSeconds(fireDelay);
                shooter.Fire(transform.forward);
            }
        }

        public void Update()
        {
            if(IsManned)
            {
                rot.Update();
                mover.Update();
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