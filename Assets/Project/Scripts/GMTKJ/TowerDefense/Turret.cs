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

        private RotateByMouse rot;
        private Shooter shooter;
        [SerializeField]
        private RotateByMouse.Settings rotationSettings;
        [SerializeField]
        private Transform shootingSpot;
        [SerializeField]
        private Transform selectIndicator;

        public bool IsManned{get; set;}

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
                if(Input.GetMouseButtonDown(0))
                {
                    shooter.Fire(transform.forward);
                }

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    IngameScene.Current.Player.gameObject.SetActive(true);
                    IsManned = false;
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