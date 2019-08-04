using UnityEngine;
using DG.Tweening;
using System;

namespace GMTKJ.TowerDefense.EnemyStates
{
    public class DyingState : EnemyState
    {
        protected override void Begin()
        {
            Context.transform.DOScale(Vector3.zero, .5f).OnComplete(OnKillAnimationOver);
        }

        private void OnKillAnimationOver()
        {
            ChangeState(new CleanupState());
        }
    }
}