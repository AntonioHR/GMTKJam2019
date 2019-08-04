using System;
using System.Collections;
using GMTKJ.Bullets;
using GMTKJ.Movement;
using GMTKJ.Ui;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Turret : MonoBehaviour, IHittable
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
        [SerializeField]
        private OnDemandHealthBar bar;

        public bool IsManned{
            get
            {
                return isManned;
            } set
            {
                if(value)
                    chargeShots = maxChargeShots;

                isManned = value;
            }
        }
        public int chargeShots;
        public int maxChargeShots = 5;
        private bool isManned;

        public void Start()
        {
            mover = new TwoPointMover(transform, setup);
            rot = new RotateByMouse(IngameScene.Current.Cursor, transform, rotationSettings);
            shooter = new Shooter(bulletPrefab, shootingSpot, IngameScene.Current.BulletsFolder);
            bar.max = maxChargeShots;
            StartCoroutine(AutoFire(fireDelay));
        }

        private IEnumerator AutoFire(float fireDelay)
        {
            while(true)
            {
                yield return new WaitForSeconds(fireDelay);
                if(IsManned || chargeShots > 0)
                {
                    if(!IsManned)
                        chargeShots--;
                    UpdateShotsBar();
                    shooter.Fire(transform.forward, this);
                }
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

        public void OnHitBy(Bullet bullet)
        {
            chargeShots = maxChargeShots;
            UpdateShotsBar();
        }

        private void UpdateShotsBar()
        {
            bar.OnUpdate(chargeShots);
        }
    }
}