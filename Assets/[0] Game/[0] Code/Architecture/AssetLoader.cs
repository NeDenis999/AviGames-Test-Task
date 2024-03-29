using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game
{
    public class AssetLoader : MonoBehaviour
    {
        [SerializeField]
        private List<string> _levels;
        
        [Inject]
        private AssetProvider _assetProvider;
        
        public IEnumerator AwaitLoad()
        {
            AsyncOperationHandle<IList<GameObject>> loadWithMultipleKeys =
                Addressables.LoadAssetsAsync<GameObject>(_levels,
                    obj => { }, 
                    Addressables.MergeMode.Union);
            yield return loadWithMultipleKeys;

            if (loadWithMultipleKeys.Status == AsyncOperationStatus.Succeeded)
            {
                _assetProvider.Levels = loadWithMultipleKeys.Result
                    .Where(x => x != null && x.GetComponent<Picture>() != null)
                    .Select(x => x.GetComponent<Picture>())
                    .ToList();
            }
            else
            {
                Debug.LogError("Failed to load assets with multiple keys.");
            }
        }
    }
}