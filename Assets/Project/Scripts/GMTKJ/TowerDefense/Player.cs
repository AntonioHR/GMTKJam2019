using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GMTKJ.Movement;

namespace GMTKJ.TowerDefense
{
    public class Player : MonoBehaviour
    {
        private PlayerStateMachine stateMachine;

        public CharacterController charController;
        [SerializeField]
        private  MoveByController.Setup moveSetup;
        public MoveByController mover;
        public TurretChecker turretChecker;
        public PlayerBody body;



        private Turret MannedTurret;


        void Awake()
        {
            turretChecker.Init(this);
        }
        void Start()
        {
            mover = new MoveByController(charController, moveSetup);
            stateMachine = new PlayerStateMachine();
            stateMachine.Init(this);
        }

        void Update()
        {
            stateMachine.Update();
        }

        public void OnClosestTurretChanged(Turret from, Turret to)
        {
            stateMachine.OnClosestTurretChanged(from, to);
        }
    }
}