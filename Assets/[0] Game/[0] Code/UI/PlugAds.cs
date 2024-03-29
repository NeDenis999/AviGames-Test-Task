using System.Collections;
using UnityEngine;

namespace Game
{
    public class PlugAds : MonoBehaviour
    {
        private Coroutine _coroutine;

        private IEnumerator AwaitShow()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }

        public void Show()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            gameObject.SetActive(true);
            _coroutine = StartCoroutine(AwaitShow());
        }
    }
}