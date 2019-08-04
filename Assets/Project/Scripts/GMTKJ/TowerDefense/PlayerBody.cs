using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace GMTKJ.TowerDefense
{
    public class PlayerBody : MonoBehaviour
    {
        private Vector3 basePos;
        private TweenerCore<Vector3, Vector3, VectorOptions> floatTween;

        public void Start()
        {
            basePos = transform.localPosition;
            StartFloatTween();
        }

        internal void Reset(object onBodyLeft)
        {
            throw new NotImplementedException();
        }

        private void StartFloatTween()
        {
            floatTween = transform.DOLocalMove(basePos + Vector3.up * 1, .5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }

        public void MoveInto(Turret current, TweenCallback callback)
        {
            floatTween.Kill();
            var seq  = DOTween.Sequence();
            seq.Join(transform.DOMove(current.transform.position, .5f));
            seq.Join(transform.DOScale(Vector3.zero, .5f));
            seq.AppendCallback(callback);
        }
        public void Reset(TweenCallback callback)
        {
            var seq  = DOTween.Sequence();            
            seq.Join(transform.DOLocalMove(basePos, .5f));
            seq.Join(transform.DOScale(Vector3.one, .5f));
            seq.AppendCallback(callback);
            seq.AppendCallback(StartFloatTween);
        }

    }
}