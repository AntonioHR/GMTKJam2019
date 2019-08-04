using System;
using UnityEngine;

namespace GMTKJ.Movement
{
    public class RotateByMouse 
    {
        [Serializable]
        public class Settings
        {
            public bool lockVertical = true;
        }
        private Transform transform;
        private Quaternion baseRotation;
        private PlaneCursor cursor;
        private Settings settings;

        public RotateByMouse(PlaneCursor cursor, Transform transform, Settings settings) : this(cursor, transform, transform.rotation, settings)
        {
        }
        public RotateByMouse(PlaneCursor cursor, Transform transform, Quaternion baseRotation, Settings settings)
        {
            this.transform = transform;
            this.baseRotation = baseRotation;
            this.cursor = cursor;
            this.settings = settings;
        }

        public void Update()
        {
            var pos = cursor.MousePos;
            if(pos != null)
            {
                Vector3 delta = transform.position - cursor.MousePos.Value;
                if(settings.lockVertical)
                    delta.y = 0;
                transform.rotation = baseRotation * Quaternion.LookRotation(delta);
            }
        }
    }
}