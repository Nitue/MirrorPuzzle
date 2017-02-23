using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Installers
{
    public class MirrorInstaller : MonoInstaller<MirrorInstaller>
    {
        public override void InstallBindings()
        {
            // Here we could change the reflection logic for Mirrors
            Container.Bind<IReflector>().To<PerfectReflector>().WhenInjectedInto<Mirror>();
        }
    }
}