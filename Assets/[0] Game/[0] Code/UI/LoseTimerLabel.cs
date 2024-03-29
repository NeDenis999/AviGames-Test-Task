using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public class LoseTimerLabel : MonoBehaviour
    {
        [Inject]
        private AssetProvider assetProvider;
        
        private TMP_Text _label;
        private int _remainingTime;
        
        private IEnumerator Start()
        {
            _label = GetComponent<TMP_Text>();
            _remainingTime = assetProvider.StartLoseTime;
            UpgradeLabel();
            
            while (_remainingTime > 0)
            {
                yield return new WaitForSeconds(1);
                _remainingTime -= 1;

                UpgradeLabel();
            }
            
            EventBus.Lose?.Invoke();
        }

        private void UpgradeLabel()
        {
            var minutes = _remainingTime / 60;
            var seconds = _remainingTime % 60;
            _label.text = "" + (minutes < 10 ? 0.ToString() : "") + minutes + ':' + (seconds < 10 ? 0.ToString() : "") + seconds;
        }
    }
}