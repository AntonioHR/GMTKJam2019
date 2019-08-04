using AntonioHR.Interactables;
using GMTKJ.TowerDefense;
using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Bullet : ObjectTrigger<IHittable>
    {
        public float speed = 20;
        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private int damage = 1;

        public int Damage { get{return damage;}}
        public Vector3 Velocity { get{return rb.velocity;}}

        public void Shoot(Vector3 direction)
        {
            rb.velocity = direction.normalized * speed;
            Destroy(gameObject, 10);
        }

        protected override void OnTriggered(IHittable hittable)
        {
            hittable.OnHitBy(this);
            GameObject.Destroy(gameObject);
        }
    }
}