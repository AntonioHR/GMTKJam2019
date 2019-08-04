using System;
using GMTKJ.Bullets;
using GMTKJ.StateMachines;
using GMTKJ.TowerDefense.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace GMTKJ.TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public int StartingHealth;
        [NonSerialized]
        public int CurrentHealth;
        public NavMeshAgent NavMeshAgent;
        private EnemyStateMachine stateMachine = new EnemyStateMachine();

        public void OnNearNexus(Nexus nexus)
        {
            stateMachine.OnNearNexus(nexus);
        }

        private void Start()
        {
            stateMachine.Init(this);
        }
        public void OnHitBy(Bullet bullet)
        {
            stateMachine.OnHitBy(bullet);
            Destroy(gameObject);
        }
    }
    public class EnemyStateMachine : StateMachine<Enemy, EnemyState>
    {
        public override EnemyState DefaultState => new StartupState();

        public void OnHitBy(Bullet bullet)
        {
            CurrentState.OnHitBy(bullet);
        }

        public void OnNearNexus(Nexus nexus)
        {
            CurrentState.OnNearNexus(nexus);
        }
    }
    public abstract class EnemyState : State<Enemy, EnemyState>
    {
        public virtual void OnHitBy(Bullet bullet){}

        public virtual void OnNearNexus(Nexus nexus){}
    }
}