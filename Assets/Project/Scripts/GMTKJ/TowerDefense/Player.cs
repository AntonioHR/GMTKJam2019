using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTKJ.Movement;

namespace GMTKJ.TowerDefense
{
    public class Player : MonoBehaviour
    {
        MoveByController mover;


        [SerializeField]
        private CharacterController charController;
        [SerializeField]
        private MoveByController.Setup moveSetup;

        void Start()
        {
            mover = new MoveByController(charController, moveSetup);
        }

        void Update()
        {
            mover.Update();
        }
    }
}