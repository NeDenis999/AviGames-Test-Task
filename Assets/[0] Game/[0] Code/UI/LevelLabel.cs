using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public class LevelLabel : MonoBehaviour
    {
        private const string Title = "Уровень ";
        
        [Inject]
        private GameDataContainer _gameDataContainer;
        
        private TMP_Text _label;

        private void Start()
        {
            _label = GetComponent<TMP_Text>();
            UpgradeLabel();
        }
        
        private void UpgradeLabel()
        {
            _label.text = Title + _gameDataContainer.GameData.Level;
        }
    }
}