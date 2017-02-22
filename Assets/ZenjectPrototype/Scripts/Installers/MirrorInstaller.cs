using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Installers
{
    public class MirrorInstaller : MonoInstaller<MirrorInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IReflector>().To<PerfectReflector>().WhenInjectedInto<Mirror>();
        }
    }
}