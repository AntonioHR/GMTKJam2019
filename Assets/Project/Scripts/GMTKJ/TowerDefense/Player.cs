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
            mover.Update();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(turretChecker.Current != null)
                {
                    turretChecker.Current.IsManned = true;
                    gameObject.SetActive(false);
                }
            }
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