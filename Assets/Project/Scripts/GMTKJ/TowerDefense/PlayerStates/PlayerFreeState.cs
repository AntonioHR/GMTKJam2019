using System;
using GMTKJ.TowerDefense;
using UnityEngine;

namespace GMTKJ.TowerDefense.PlayerStates
{
    public class PlayerFreeState : PlayerState
    {
        public override bool AllowTurretTargets{get=>true;}
        public override void Update()
        {
            Context.mover.Update();
                if(PressedTurretToggle)
                {
                    if(Context.turretChecker.Current != null)
                    {
                        StartManning(Context.turretChecker.Current);
                    }
            }
        }

        private void StartManning(Turret current)
        {
            ChangeState(new MoveIntoTurretState(current));
        }
    }
}