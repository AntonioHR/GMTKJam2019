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
            if(Context.turretChecker.Current != null)
                Context.turretChecker.Current.OnSelect();
            turret.IsManned = false;
            Context.body.Reset(OnLeftTurret);
        }

        private void OnLeftTurret()
        {
            ExitTo(new PlayerFreeState());
        }
    }
}