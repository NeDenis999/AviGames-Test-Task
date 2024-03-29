using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class MoveToPointAnimation : MonoBehaviour
    {
        [SerializeField]
        private Transform _startPoint;

        [SerializeField]
        private Transform _targetPoint;

        [SerializeField]
        private float _startDuration;
        
        [SerializeField]
        private float _duration = 0.5f;

        private Sequence _sequence;

        public void Start()
        {
            transform.position = _startPoint.position;
            _sequence = DOTween.Sequence();
            _sequence.SetDelay(_startDuration);
            _sequence.Append(transform.DOMove(_targetPoint.position, _duration).SetEase(Ease.Linear));
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}