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
            navMeshAgent.destination = target.position;
        }
    }
}