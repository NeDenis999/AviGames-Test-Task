using UnityEngine;
using Zenject;

namespace Game
{
    public class GameRules : MonoBehaviour
    {
        [Inject]
        private ScreensManager _screensManager;

        [Inject]
        private SaveLoadService _saveLoadService;

        [Inject]
        private GameDataContainer _gameDataContainer;

        private void Awake()
        {
            EventBus.DifferenceUpgrade += OnDifferenceUpgrade;
            EventBus.Lose += OnLose;
        }

        private void OnDestroy()
        {
            EventBus.DifferenceUpgrade = null;
            EventBus.Lose = null;
        }

        private void OnDifferenceUpgrade(int value, int maxValue)
        {
            if (value == maxValue)
            {
                Win();
            }
        }

        [ContextMenu("Победить")]
        private void Win()
        {
            _screensManager.HideScreen(ScreenType.Main);
            _screensManager.ShowScreen(ScreenType.Win);
                
            _gameDataContainer.GameData.Level++;
            _saveLoadService.Save();
        }

        [ContextMenu("Проиграть")]
        private void OnLose()
        {
            _screensManager.HideScreen(ScreenType.Main);
            _screensManager.ShowScreen(ScreenType.Lose);
        }
    }
}