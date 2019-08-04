using AntonioHR.Interactables;
using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Bullet : ObjectTrigger<Enemy>
    {
        public float vel = 5;
        [SerializeField]
        private Rigidbody rb;

        public void Shoot(Vector3 direction)
        {
            rb.velocity = direction.normalized * vel;
        }

        protected override void OnTriggered(Enemy enemy)
        {
            enemy.OnHitBy(this);
        }
    }
}