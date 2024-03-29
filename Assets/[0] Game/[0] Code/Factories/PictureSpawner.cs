using System.Linq;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PictureSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint1, _spawnPoint2;
        
        private PictureFactory _pictureFactory;
        private GameDataContainer _gameDataContainer;

        [Inject]
        private void Construct(PictureFactory pictureFactory, GameDataContainer gameDataContainer)
        {
            _pictureFactory = pictureFactory;
            _gameDataContainer = gameDataContainer;
        }
        
        public void Spawn()
        {
            var picture1 = _pictureFactory.Create();
            picture1.transform.position = _spawnPoint1.position;
            picture1.transform.SetParent(_spawnPoint1);
            
            var picture2 = _pictureFactory.Create();
            picture2.transform.position = _spawnPoint2.position;
            picture2.transform.SetParent(_spawnPoint2);
            
            picture1.Init(picture2);

            _gameDataContainer.GameData.StartDifference = picture1.Differences.ToArray().Length;
            _gameDataContainer.GameData.Difference = 0;
            
            EventBus.DifferenceUpgrade?.Invoke(_gameDataContainer.GameData.Difference, _gameDataContainer.GameData.StartDifference);
        }
    }
}