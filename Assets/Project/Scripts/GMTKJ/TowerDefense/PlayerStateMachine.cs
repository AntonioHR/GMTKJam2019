using System;
using GMTKJ.StateMachines;
using GMTKJ.TowerDefense.PlayerStates;

namespace GMTKJ.TowerDefense
{
    public class PlayerStateMachine : StateMachine<Player, PlayerState>
    {
        public override PlayerState DefaultState => new PlayerFreeState();


        public void Update()
        {
            CurrentState.Update();
        }


        public void OnClosestTurretChanged(Turret from, Turret to)
        {
            CurrentState.OnClosestTurretChanged(from, to);
        }
    }
}