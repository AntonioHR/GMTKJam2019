using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GMTKJ.Ui
{
    public class OnDemandHealthBar : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private Image img;
        [NonSerialized]
        public float max;
        private Tween tween;

        private void Start()
        {
            canvasGroup.alpha = 0;
        }

        public void OnUpdate(int current)
        {
            img.fillAmount = (float)current/max;

            if(tween != null)
                tween.Kill();

            var seq = DOTween.Sequence();
            seq.Append(canvasGroup.DOFade(1f, .25f));
            seq.AppendInterval(.5f);
            seq.Append(canvasGroup.DOFade(0, .25f));
            tween = seq;
        }
    }
}