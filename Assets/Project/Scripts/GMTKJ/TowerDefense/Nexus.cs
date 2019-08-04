using System;
using GMTKJ.TowerDefense.EnemyStates;
using GMTKJ.Ui;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Nexus : MonoBehaviour
    {
        [SerializeField]
        private OnDemandHealthBar bar;
        [NonSerialized]
        public int Health;
        public int StartingHealth = 10;
        public void Start()
        {
            Health = StartingHealth;
            bar.max = StartingHealth;
        }
        public void HitBy(AttackingState attackingState)
        {
            Health --;
            bar.OnUpdate(Health);
            if (Health == 0)
                Die();
        }

        private void Die()
        {
            IngameScene.Current.OnNexusDead(this);
        }
    }
}