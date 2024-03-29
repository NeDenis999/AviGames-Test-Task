using System.Collections;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStartup : MonoBehaviour
    {
        [Inject]
        private PictureFactory _pictureFactory;

        [Inject]
        private AssetLoader _assetLoader;

        public IEnumerator Start()
        {
            _assetLoader.Load();
            yield return new WaitUntil(() => _assetLoader.IsComplete);
            _pictureFactory.Spawn();
        }
    }
}
