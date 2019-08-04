using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public float vel = 5;
        [SerializeField]
        private Rigidbody rb;

        public void Shoot(Vector3 direction)
        {
            rb.velocity = direction.normalized * vel;
            Debug.Log(rb.velocity);
        }
    }
}