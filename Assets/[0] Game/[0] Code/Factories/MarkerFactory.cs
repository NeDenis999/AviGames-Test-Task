using UnityEngine;
using Zenject;

namespace Game
{
    public class MarkerFactory : MonoBehaviour
    {
        [Inject]
        private AssetProvider _assetProvider;

        [SerializeField]
        private RectTransform _container;
        
        public Marker Spawn(Vector3 position)
        {
            return Instantiate(_assetProvider.Maker, position, Quaternion.identity,_container);
        }
    }
}