using System;
using GMTKJ.StateMachines;
using GMTKJ.TowerDefense.PlayerStates;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public abstract class PlayerState : State<Player, PlayerState>
    {
        public virtual bool AllowTurretTargets{get=>false;}
        public bool PressedTurretToggle
        {
            get
            {
                return Input.GetKeyDown(KeyCode.Space);
            }
            
        }
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

        public virtual void OnNexusDead()
        {
            ChangeState(new DeadState());
        }
    }
}