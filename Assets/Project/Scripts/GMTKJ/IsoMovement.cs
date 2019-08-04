using UnityEngine;

namespace GMTKJ
{
    public static class IsoMovement
    {
        public readonly static Vector3 Forward = Quaternion.AngleAxis(-45, Vector3.up) * Vector3.back ;
        public readonly static Vector3 Right = Quaternion.AngleAxis(-45, Vector3.up) * Vector3.right ;
        public static Vector3 CurrentInput
        {
            get
            {
                return Forward * Input.GetAxis("Horizontal") + Right * Input.GetAxis("Vertical");
            }

        }
    }
}