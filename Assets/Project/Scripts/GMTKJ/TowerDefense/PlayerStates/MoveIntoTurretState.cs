using System;

namespace GMTKJ.TowerDefense.PlayerStates
{
    internal class MoveIntoTurretState : PlayerState
    {
        private Turret current;

        public MoveIntoTurretState(Turret current)
        {
            this.current = current;
        }
        protected override void Begin()
        {
            current.OnDeselect();

            Context.body.MoveInto(current, OnAnimatedIntoTurret);
        }

        private void OnAnimatedIntoTurret()
        {
            ExitTo(new InsideTurretState(current));
        }
    }
}