namespace GMTKJ.TowerDefense.EnemyStates
{
    public class IdleState : EnemyState
    {
        protected override void Begin()
        {
            Context.NavMeshAgent.destination = IngameScene.Current.Nexus.transform.position;
        }
        public override void OnNearNexus(Nexus nexus)
        {
            ExitTo(new AttackingState());
        }
    }
}