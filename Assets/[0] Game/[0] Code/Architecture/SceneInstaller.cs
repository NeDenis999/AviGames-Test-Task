using UnityEngine;
using Zenject;

namespace Game
{
    public class SceneInstaller : MonoInstaller
    {
        [Header("Factories")]
        [SerializeField]
        private PictureFactory _pictureFactory;

        [SerializeField]
        private MarkerFactory _markerFactory;
        
        [Header("Spawners")]
        [SerializeField]
        private PictureSpawner _pictureSpawner;
        
        [SerializeField]
        private MarkerSpawner _markerSpawner;
        
        [Space]
        [SerializeField]
        private ScreensManager _screensManager;
        
        [SerializeField]
        private Bootstrap bootstrap;
        
        public override void InstallBindings()
        {
            this.Bind(_pictureFactory, Container);
            this.Bind(_markerFactory, Container);
            this.Bind(_pictureSpawner, Container);
            this.Bind(_markerSpawner, Container);
            this.Bind(_screensManager, Container);
            this.Bind(bootstrap, Container);
        }
    }
}