using System;
using DG.Tweening;
using UnityEngine;

namespace GMTKJ.TowerDefense.EnemyStates
{
    public class AttackingState : IdleState
    {
        private Sequence tween;

        protected override void Begin()
        {
            Context.NavMeshAgent.isStopped = true;
            Context.transform.LookAt(IngameScene.Current.Nexus.transform.position);
            tween = DOTween.Sequence();
            tween.Append(Context.transform.DOPunchScale(Vector3.forward * 0.2f, 0.1f)).SetEase(Ease.InQuad);
            tween.AppendCallback(OnAttackKeyFrame);
            tween.AppendInterval(1);
            tween.SetLoops(-1);

        }

        private void OnAttackKeyFrame()
        {
            IngameScene.Current.Nexus.HitBy(this);
        }

        protected override void End()
        {
            tween.Kill();
        }
    }
}