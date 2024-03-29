using System.Collections;
using System.Collections.Generic;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Bootstrap : MonoBehaviour, IAppodealInitializationListener
    {
        private PictureSpawner _pictureSpawner;
        private AssetLoader _assetLoader;

        [Inject]
        private void Construct(PictureSpawner pictureSpawner, AssetLoader assetLoader)
        {
            _pictureSpawner = pictureSpawner;
            _assetLoader = assetLoader;
        }

        public IEnumerator Start()
        {
            yield return _assetLoader.AwaitLoad();

#if UNITY_EDITOR
            InitAppMetrica();
            InitAppodeal();
#endif

            _pictureSpawner.Spawn();
        }

        public void onInitializationFinished(List<string> errors) { }

        private void InitAppMetrica()
        {
            AppMetrica.Instance.RequestTrackingAuthorization (status =>
            {
                print("AppMetrica Init");
            });
        }

        private void InitAppodeal()
        {
            int adTypes = Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO | Appodeal.MREC;
            string appKey = "YOUR_APPODEAL_APP_KEY";
            Appodeal.initialize(appKey, adTypes, this);   
        }
    }
}
