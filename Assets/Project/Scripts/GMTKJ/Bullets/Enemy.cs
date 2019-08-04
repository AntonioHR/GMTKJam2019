using System;
using UnityEngine;

namespace GMTKJ.Bullets
{
    public class Enemy : MonoBehaviour
    {
        public void OnHitBy(Bullet bullet)
        {
            Destroy(gameObject);
        }
    }
}