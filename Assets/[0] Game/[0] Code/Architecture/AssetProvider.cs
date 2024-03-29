using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Game
{
    [CreateAssetMenu(fileName = "AssetProvider", menuName = "Configs/AssetProvider", order = 30)]
    public class AssetProvider : ScriptableObjectInstaller<AssetProvider>
    {
        public Picture Picture;
        public AudioMixerGroup Mixer;
        public GameObject ClickTrueEffect;
        public GameObject ClickFalseEffect;
        public int GameSceneIndex;
        public int StartLoseTime;
        public Marker Maker;
        
        public override void InstallBindings()
        {
            Container.Bind<AssetProvider>().FromInstance(this).AsSingle().NonLazy();
        }
    }
}