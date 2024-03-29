using GMTKJ.Bullets;
using UnityEngine;

namespace GMTKJ.TowerDefense.EnemyStates
{
    public class CleanupState : EnemyState
    {
        protected override void Begin()
        {
            GameObject.Destroy(Context.gameObject);
        }
        public override void OnHitBy(Bullet bullet){}
    }
}