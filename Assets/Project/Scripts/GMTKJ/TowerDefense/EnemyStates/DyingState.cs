using UnityEngine;
using DG.Tweening;
using System;
using GMTKJ.Bullets;

namespace GMTKJ.TowerDefense.EnemyStates
{
    public class DyingState : EnemyState
    {
        protected override void Begin()
        {
            var seq = DOTween.Sequence();
            seq.Append(Context.transform.DOScaleZ(0f, 0.5f));
            seq.Join(Context.transform.DOMove(Vector3.up *1.5f, .5f).SetRelative());
            seq.Insert(.25f, Context.transform.DOScale(Vector3.zero, .25f));
            seq.AppendCallback(OnKillAnimationOver);
        }
        public override void OnHitBy(Bullet bullet){}
        private void OnKillAnimationOver()
        {
            ExitTo(new CleanupState());
        }
    }
}