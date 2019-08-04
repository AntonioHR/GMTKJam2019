namespace GMTKJ.TowerDefense.EnemyStates
{
    public class IdleState : EnemyState
    {
        protected override void Begin()
        {
            Context.NavMeshAgent.destination = IngameScene.Current.Nexus.transform.position;
        }
        public override void OnHitBy(Bullets.Bullet bullet)
        {
            Context.CurrentHealth-= bullet.Damage;
            if(Context.CurrentHealth < 0) 
                ChangeState(new DyingState());
                ChangeState(new StartupState());
        }
        public override void OnNearNexus(Nexus nexus)
        {
            ChangeState(new AttackingState());
        }
    }
}