using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Obstacle : MonoBehaviour, IHittable
    {
        public BoxCollider[] cols;

        [NaughtyAttributes.Button]
        public void Safadeza()
        {
            foreach(var col in cols)
            {
                col.size -= Vector3.one *  .2f;
            }
        }
        public void OnHitBy(Bullet bullet)
        {
            AudioManager.Instance.PlayFx("WallDamaged");
        }
    }
}