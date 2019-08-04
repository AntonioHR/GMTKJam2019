using System;
using System.Collections;
using DG.Tweening;
using GMTKJ.Bullets;
using GMTKJ.Movement;
using GMTKJ.Ui;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Turret : MonoBehaviour, IHittable
    {
        [SerializeField]
        private GlowIndicactor glow;
        [SerializeField]
        private Bullet bulletPrefab;
        [SerializeField]
        private float fireDelay;
        private TwoPointMover mover;
        private MoveByController move;
        private RotateByMouse rot;
        private Shooter shooter;
        [SerializeField]
        private RotateByMouse.Settings rotationSettings;
        [SerializeField]
        private Transform shootingSpot;
        [SerializeField]
        private CanvasGroup selectIndicator;
        [SerializeField]
        private TwoPointMover.Setup setup;
        [SerializeField]
        private MoveByController.Setup moveByControllerSetup;
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
        [SerializeField]
        private CharacterController charController;

        public void Start()
        {
            mover = new TwoPointMover(transform, setup);
            move = new MoveByController(charController, moveByControllerSetup);
            rot = new RotateByMouse(IngameScene.Current.Cursor, transform, rotationSettings);
            shooter = new Shooter(bulletPrefab, shootingSpot, IngameScene.Current.BulletsFolder);
            bar.max = maxChargeShots;
            StartCoroutine(AutoFire(fireDelay));
            glow.SetTo(0);
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
                // mover.Update();
                move.Update();
            }
        }

        public void OnDeselect()
        {
            DOTween.Kill(selectIndicator);
            selectIndicator.DOFade(0, .25f);
        }

        public void OnSelect()
        {
            DOTween.Kill(selectIndicator);
            selectIndicator.DOFade(1, .25f);
        }

        public void OnHitBy(Bullet bullet)
        {
            chargeShots = maxChargeShots;
            UpdateShotsBar();
        }

        private void UpdateShotsBar()
        {
            bar.OnUpdate(chargeShots);
            glow.SetTo((float)chargeShots/(float)maxChargeShots);
        }
    }
}