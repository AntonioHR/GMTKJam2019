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
        private Vector3 fwd;
        private Vector3 right;

        public MoveByController(CharacterController controller) : this(controller, new Setup())
        {
        }
        public MoveByController(CharacterController controller, Setup setup)
        {
            this.controller = controller;
            this.setup = setup;

            fwd = Quaternion.AngleAxis(-45, Vector3.up) * Vector3.back ;
            right = Quaternion.AngleAxis(-45, Vector3.up) * Vector3.right ;

        }

        public void Update()
        {
            Vector3 input = fwd * Input.GetAxis("Horizontal") + right * Input.GetAxis("Vertical");
            controller.SimpleMove(input * setup.speed);
        }
    }
}