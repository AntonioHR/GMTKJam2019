using UnityEngine;

namespace GMTKJ.Movement
{
    public class PlaneCursor : MonoBehaviour
    {
        [SerializeField]
        public LayerMask mask;
        [SerializeField]
        private Collider col;
        public void Start()
        {

        }

        public Vector3? MousePos
        {
            get
            {
                RaycastHit info;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray.origin, ray.direction, out info, float.PositiveInfinity, mask.value))
                {
                    return info.point;
                } else
                {
                    return null;
                }
            }
        }
        
    }
}