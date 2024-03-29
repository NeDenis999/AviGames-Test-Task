using UnityEngine;

namespace Game
{
    public class Difference : MonoBehaviour
    {
        private bool _isClick;
        private Difference _pair;

        public Difference Pair => _pair;

        public bool TryClick()
        {
            if (_isClick)
                return false;

            _isClick = true;
            return true;
        }

        public void Init(Picture picture, Difference difference)
        {
            _pair = difference;
        }

        public void Hide()
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }
}