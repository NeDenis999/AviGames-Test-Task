using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _startSize = 0.75f;

        [SerializeField]
        private float _targetSize = 1f;

        [SerializeField]
        private float _duration = 0.5f;

        private Sequence _sequence;

        public void Start()
        {
            transform.localScale = Vector3.one * _startSize;
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_targetSize, _duration).SetEase(Ease.OutBack));
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}