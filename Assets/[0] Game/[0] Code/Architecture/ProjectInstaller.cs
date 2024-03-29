using UnityEngine;
using Zenject;

namespace Game
{
    public class ProjectInstaller : MonoInstaller, IInitializable

    {
        [SerializeField]
        private SaveLoadService _saveLoadService;
        
        [SerializeField]
        private GameDataContainer _gameDataContainer;
        
        [SerializeField]
        private AssetLoader _assetLoader;
        
        public override void InstallBindings()
        {
            this.Bind(_saveLoadService, Container);
            this.Bind(_gameDataContainer, Container);
            this.Bind(_assetLoader, Container);
            
            Container
                .Bind<IInitializable>()
                .To<ProjectInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        public void Initialize()
        {
            _saveLoadService.Initialize();
        }
    }
}