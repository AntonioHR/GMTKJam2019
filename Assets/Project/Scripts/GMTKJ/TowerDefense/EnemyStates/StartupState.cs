using System;
using DG.Tweening;
using UnityEngine;

namespace GMTKJ.TowerDefense.EnemyStates
{
    public class StartupState : EnemyState
    {
        protected override void Begin()
        {
            Context.CurrentHealth = Context.StartingHealth;
            Context.transform.DOScale(Vector3.zero, .5f).From().OnComplete(OnAppear);
        }

        private void OnAppear()
        {
            ChangeState(new IdleState());
        }
    }
}