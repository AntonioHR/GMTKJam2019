using System;
using GMTKJ.TowerDefense.EnemyStates;
using GMTKJ.Ui;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class Nexus : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer meshRenderer;
        [SerializeField]
        private OnDemandHealthBar bar;
        [NonSerialized]
        public int Health;
        public int StartingHealth = 10;
        [SerializeField]
        private float zeroHealthVal;
        [SerializeField]
        private float fullHealthVal;
        [SerializeField]
        private string propName;

        public void Start()
        {
            Health = StartingHealth;
            bar.max = StartingHealth;
        }
        public void HitBy(AttackingState attackingState)
        {
            Health --;
            bar.OnUpdate(Health);
            foreach(var mat in meshRenderer.materials)
            {
                mat.SetFloat(propName, Mathf.Lerp(zeroHealthVal, fullHealthVal, (float)Health/(float)StartingHealth));
            }
            if (Health == 0)
                Die();
        }

        private void Die()
        {
            IngameScene.Current.OnNexusDead(this);
        }
    }
}