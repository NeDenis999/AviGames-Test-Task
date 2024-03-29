using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PointingCursorScaleAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private float _minSize = 0.75f;

        [SerializeField]
        private float _normalSize = 1f;

        [SerializeField]
        private float _durationDown = 0.5f;
        
        [SerializeField]
        private float _durationUp = 0.5f;

        private Sequence _sequence;

        public void Start()
        {
            _sequence = DOTween.Sequence();
        }

        private void OnDestroy()
        {
            _sequence?.Kill();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_minSize, _durationDown).SetEase(Ease.Linear));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_normalSize, _durationUp).SetEase(Ease.OutBack));
        }
    }
}