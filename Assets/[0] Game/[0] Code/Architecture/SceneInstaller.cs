using UnityEngine;
using Zenject;

namespace Game
{
    public class SceneInstaller : MonoInstaller
    {
        [Header("Factories")]
        [SerializeField]
        private MarkerFactory _markerFactory;
        
        [SerializeField]
        private PictureFactory _pictureFactory;

        [Space]
        [SerializeField]
        private ScreensManager _screensManager;
        
        [SerializeField]
        private GameStartup _gameStartup;
        
        public override void InstallBindings()
        {
            this.Bind(_markerFactory, Container);
            this.Bind(_pictureFactory, Container);
            this.Bind(_screensManager, Container);
            this.Bind(_gameStartup, Container);
        }
    }
}