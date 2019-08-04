using AntonioHR.Interactables;
using GMTKJ.TowerDefense;
using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Bullet : ObjectTrigger<Enemy>
    {
        public float vel = 5;
        [SerializeField]
        private Rigidbody rb;
        private int damage = 1;

        public int Damage { get{return damage;}}

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