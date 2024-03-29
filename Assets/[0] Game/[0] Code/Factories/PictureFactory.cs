using UnityEngine;
using Zenject;

namespace Game
{
    public class PictureFactory : MonoBehaviour, IFactory
    {
        [Inject]
        private AssetProvider _assetProvider;

        public Picture Create()
        {
            return Instantiate(_assetProvider.Levels[0]);
        }
    }
}