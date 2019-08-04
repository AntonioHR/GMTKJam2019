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
            turret.IsManned = true;
        }
        public override void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(new LeavingTurretState(turret));
            }
        }

    }
}