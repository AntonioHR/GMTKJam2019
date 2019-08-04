using System;
using GMTKJ.StateMachines;

namespace GMTKJ.TowerDefense
{
    public abstract class PlayerState : State<Player, PlayerState>
    {
        public virtual bool AllowTurretTargets{get=>false;}
        public virtual void Update(){}

        public virtual void OnClosestTurretChanged(Turret from, Turret to)
        {
            if(AllowTurretTargets)
            {
                if(from!= null)
                    from.OnDeselect();
                if(to != null)
                    to.OnSelect();
            }
        }
    }
}