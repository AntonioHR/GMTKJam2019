using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GMTKJ.Ai
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class GoToTarget : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        [SerializeField]
        private Transform target;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            if(target != null)
                navMeshAgent.destination = target.position;
        }

        public void SetTarget(Transform newDestination)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.destination = newDestination.position;
        }
    }
}