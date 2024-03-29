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
            AppMetrica.Instance.ReportEvent(EventName);
            FindObjectOfType<PlugRestartEvent>(true).Show();
            
            SceneManager.LoadScene(assetProvider.GameSceneIndex);
            
            if(Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.INTERSTITIAL);
                FindObjectOfType<PlugAds>(true).Show();
            }
        }
    }
}