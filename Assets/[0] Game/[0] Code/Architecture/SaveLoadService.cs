using UnityEngine;
using Zenject;

namespace Game
{
    public class SaveLoadService : MonoBehaviour, IInitializable
    {
        private const string GameDataKey = "GameData";
        
        [Inject]
        private GameDataContainer _gameDataContainer;

        private string GetJson => JsonUtility.ToJson(_gameDataContainer.GameData);
        
        public void Initialize()
        {
            Load();
        }

        public void Save()
        {
            PlayerPrefs.SetString(GameDataKey, GetJson);
        }

        public void Load()
        {
            var json = PlayerPrefs.GetString(GameDataKey, GetJson);
            _gameDataContainer.GameData = JsonUtility.FromJson<GameData>(json); 
        }
    }
}