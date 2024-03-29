using AppodealAds.Unity.Api;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class RestartLevelButton : BaseButton
    {
        private const string EventName = "Restart";
        
        [Inject]
        private AssetProvider assetProvider;

        protected override void OnClick()
        {
#if UNITY_EDITOR
            AppMetrica.Instance.ReportEvent(EventName);  
            
            if(Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.INTERSTITIAL);
            }
#endif
            
            FindObjectOfType<PlugRestartEvent>(true).Show();
            FindObjectOfType<PlugAds>(true).Show();
            SceneManager.LoadScene(assetProvider.GameSceneIndex);
        }
    }
}