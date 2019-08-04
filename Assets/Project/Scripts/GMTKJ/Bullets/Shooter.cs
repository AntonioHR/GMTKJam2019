using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Shooter
    {
        public Bullet prefab;
        private Transform origin;
        private Transform folder;

        public Shooter(Bullet prefab, Transform origin, Transform folder)
        {
            this.prefab = prefab;
            this.origin = origin;
            this.folder = folder;
        }

        public void Fire(Vector3 direction, IHittable owner = null)
        {
            AudioManager.Instance.PlayFx("TowerShoot");
            var bullet = GameObject.Instantiate(prefab, origin.position, Quaternion.LookRotation(direction), folder);
            bullet.Shoot(direction, owner);
        }
    }
}