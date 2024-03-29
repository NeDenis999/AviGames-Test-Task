using Zenject;

namespace Game
{
    public static class ZenjectExtensions
    {
        public static void Bind<T>(this MonoInstaller monoInstaller, T obj, DiContainer container)
        {
            container.Bind<T>()
                .FromInstance(obj)
                .AsSingle()
                .NonLazy();
        }
    }
}