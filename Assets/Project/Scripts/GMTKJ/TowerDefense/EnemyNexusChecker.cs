using System;
using System.Linq;
using AntonioHR.Interactables;
using GMTKJ.Bullets;
using GMTKJ.StateMachines;
using GMTKJ.TowerDefense.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace GMTKJ.TowerDefense
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyNexusChecker : ObjectNearnessTrigger<Nexus>
    {
        protected override void OnHasNoObjects()
        {
        }

        protected override void OnHasObjects()
        {
            GetComponent<Enemy>().OnNearNexus(CurrentObjs.First());
        }

        protected override void UpdateNearness(Nexus player, float lerpedNearness)
        {
        }
    }
}