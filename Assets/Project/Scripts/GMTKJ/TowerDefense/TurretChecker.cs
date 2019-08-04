using System.Linq;
using AntonioHR.Interactables;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class TurretChecker : ObjectNearnessTrigger<Turret>
    {
        Player player;

        public Turret Current{get; private set;}

        public void Init(Player player)
        {
            this.player = player;
        }
        public void Start()
        {
            Debug.Assert(player != null);
        }
        protected override void AfterNearnessUpdate()
        {
            var closest = CurrentObjs.OrderBy(obj=>Vector3.Distance(transform.position, obj.transform.position)).FirstOrDefault();

            if(closest!=Current)
            {
                var from  = Current;
                Current = closest;
                player.OnClosestTurretChanged(from, closest);
            }
        }

        protected override void OnHasNoObjects()
        {}

        protected override void OnHasObjects()
        {}

        protected override void UpdateNearness(Turret player, float lerpedNearness)
        {
        }
    }
}