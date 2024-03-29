using System.Linq;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PictureFactory : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint1, _spawnPoint2;

        [Inject]
        private AssetProvider _assetProvider;

        [Inject]
        private GameDataContainer _gameDataContainer;

        public void Spawn()
        {
            var picture1 = Instantiate(_assetProvider.Picture, _spawnPoint1.position, Quaternion.identity, _spawnPoint1);
            var picture2 = Instantiate(_assetProvider.Picture, _spawnPoint2.position, Quaternion.identity, _spawnPoint2);
            
            picture1.Init(picture2);

            _gameDataContainer.GameData.StartDifference = picture1.Differences.ToArray().Length;
            _gameDataContainer.GameData.Difference = 0;
            
            EventBus.DifferenceUpgrade?.Invoke(_gameDataContainer.GameData.Difference, _gameDataContainer.GameData.StartDifference);
        }
    }
}