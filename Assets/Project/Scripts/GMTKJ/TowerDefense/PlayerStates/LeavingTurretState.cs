using System;

namespace GMTKJ.TowerDefense.PlayerStates
{
    internal class LeavingTurretState : PlayerState
    {
        private Turret turret;
        public override bool AllowTurretTargets{get=>true;}

        public LeavingTurretState(Turret turret)
        {
            this.turret = turret;
        }
        protected override void Begin()
        {
            Context.turretChecker.Current.OnSelect();
            Context.body.Reset(OnLeftTurret);
        }

        private void OnLeftTurret()
        {
            ChangeState(new PlayerFreeState());
        }
    }
}