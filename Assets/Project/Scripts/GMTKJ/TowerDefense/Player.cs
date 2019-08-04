using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTKJ.Movement;
using System;

namespace GMTKJ.TowerDefense
{
    public class Player : MonoBehaviour
    {
        private Transform meshPivot;
        MoveByController mover;


        [SerializeField]
        private CharacterController charController;
        [SerializeField]
        private MoveByController.Setup moveSetup;
        [SerializeField]
        private TurretChecker turretChecker;
        [SerializeField]
        private PlayerBody body;

        private bool isManning = false;


        void Awake()
        {
            turretChecker.Init(this);
        }
        void Start()
        {
            mover = new MoveByController(charController, moveSetup);
        }

        void Update()
        {
            if(!isManning)
            {
                mover.Update();
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if(turretChecker.Current != null)
                    {
                        StartManning(turretChecker.Current);
                    }
                }
            }
        }

        public void OnLeftTurret(Turret turret)
        {
            isManning = false;
            body.Reset();
            turret.OnSelect();
        }

        private void StartManning(Turret current)
        {
            current.OnDeselect();
            current.IsManned = true;
            isManning = true;

            body.MoveInto(current);
        }

        public void OnClosestTurretChanged(Turret from, Turret to)
        {
            if(from!= null)
                from.OnDeselect();
            if(to != null)
                to.OnSelect();
        }
    }
}