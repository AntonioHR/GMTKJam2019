using UnityEngine;

namespace GMTKJ.TowerDefense.PlayerStates
{
    internal class InsideTurretState : PlayerState
    {
        private Turret turret;

        public InsideTurretState(Turret turret)
        {
            this.turret = turret;
        }
        protected override void Begin()
        {
            Context.body.gameObject.SetActive(false);
            turret.IsManned = true;
        }
        protected override void End()
        {
            Context.body.gameObject.SetActive(true);
        }
        public override void Update()
        {
            if(PressedTurretToggle)
            {
                AudioManager.Instance.PlayFx("TowerExit");
                turret.IsManned = false;
                ExitTo(new LeavingTurretState(turret));
            }
        }

    }
}