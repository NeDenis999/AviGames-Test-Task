using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game
{
    public class AssetLoader : MonoBehaviour
    {
        [SerializeField]
        private AssetReferenceGameObject _level1;
        
        [Inject]
        private AssetProvider _assetProvider;

        public bool IsComplete;

        public void Load()
        {
            if (!_level1.IsValid())
                _level1.LoadAssetAsync().Completed += OnLevel1Loaded;
        }

        private void OnLevel1Loaded(AsyncOperationHandle<GameObject> value)
        {
            if (value.Status == AsyncOperationStatus.Succeeded)
            {
                _assetProvider.Picture = value.Result.GetComponent<Picture>();
                IsComplete = true;
            }
            else
                Debug.LogError("Loading Failed");
        }
    }
}