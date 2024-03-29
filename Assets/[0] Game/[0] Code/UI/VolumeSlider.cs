using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class VolumeSlider : MonoBehaviour
    {
        private const string MasterVolumeKey = "MasterVolume";
        private const string Title = "Звук ";

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private TMP_Text _text;

        [Inject]
        private GameDataContainer _gameDataContainer;

        [Inject]
        private AssetProvider _assetProvider;

        private void Start()
        {
            _slider.onValueChanged.AddListener(ChangeValue);
            
            _slider.value = _gameDataContainer.GameData.Volume;
            ChangeValue(_gameDataContainer.GameData.Volume);
            UpdateText();
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(ChangeValue);
        }

        private void ChangeValue(float value)
        {
            _gameDataContainer.GameData.Volume = value;
            _assetProvider.Mixer.audioMixer.SetFloat(MasterVolumeKey, Mathf.Lerp(-80, 0, value));
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = $"{Title} {(int)(_slider.value * 100)}%";
        }
    }
}