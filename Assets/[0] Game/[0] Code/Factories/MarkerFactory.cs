using UnityEngine;
using Zenject;

namespace Game
{
    public class MarkerFactory : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _container;

        [Inject]
        private AssetProvider _assetProvider;

        public Marker Create()
        {
            return Instantiate(_assetProvider.Maker, _container);
        }
    }
}