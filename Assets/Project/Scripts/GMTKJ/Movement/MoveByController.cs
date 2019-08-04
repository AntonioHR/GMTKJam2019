using System;
using UnityEngine;

namespace GMTKJ.Movement
{
    public class MoveByController
    {
        [Serializable]
        public class Setup
        {
            public float speed = 5;
        }

        private CharacterController controller;
        private Setup setup;

        public MoveByController(CharacterController controller) : this(controller, new Setup())
        {
        }
        public MoveByController(CharacterController controller, Setup setup)
        {
            this.controller = controller;
            this.setup = setup;
        }

        public void Update()
        {
            controller.SimpleMove(IsoMovement.CurrentInput * setup.speed);
        }
    }
}