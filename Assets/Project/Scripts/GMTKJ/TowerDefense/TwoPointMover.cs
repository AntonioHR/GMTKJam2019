using System;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class TwoPointMover
    {
        [Serializable]
        public class Setup{
            public Transform t1;
            public Transform t2;
            public float speed = .5f;
        }
        private Transform transform;
        private Setup setup;
        private Vector3 inputAxis;
        private float lerpPos;

        public Vector3 T1ToT2 { get=>(setup.t2.position - setup.t1.position);}
        public bool IsValid { get=>setup.t1 != null && setup.t2 != null;}

        public TwoPointMover(Transform transform, Setup setup)
        {
            this.transform = transform;
            this.setup = setup;
            if(IsValid)
                CalculateAxis();
        }

        private void CalculateAxis()
        {
            lerpPos = AsLineLerp(transform.position, true);
            transform.position = FromLineLerp(lerpPos);
        }
        private float AsLineLerp(Vector3 p, bool clamp = false)
        {
            Vector3 delta = p - setup.t1.position;
            Vector3 projDelta = Vector3.Project(delta, T1ToT2);

            float lerp = Vector3.Dot(delta, T1ToT2)/Vector3.Dot(T1ToT2, T1ToT2);
            if(clamp)
                lerp  = Mathf.Clamp(lerp, 0, 1);
            return lerp;
        }
        private Vector3 FromLineLerp(float val)
        {
            return setup.t1.position + T1ToT2 * val;
        }

        public void Update()
        {
            if(!IsValid)
                return;
            float move = Vector3.Dot(IsoMovement.CurrentInput, T1ToT2.normalized);
            lerpPos  += move * Time.deltaTime;
            lerpPos = Mathf.Clamp(lerpPos, 0, 1);
            transform.position = FromLineLerp(lerpPos);
        }
        
    }
}