using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class NextLevelButton : BaseButton
    {
        [Inject]
        private AssetProvider assetProvider;

        protected override void OnClick()
        {
            SceneManager.LoadScene(assetProvider.GameSceneIndex);
        }
    }
}