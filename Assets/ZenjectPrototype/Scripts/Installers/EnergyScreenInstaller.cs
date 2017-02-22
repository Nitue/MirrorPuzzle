using Zenject;
using ZenjectPrototype.ResourceSystem;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class EnergyScreenInstaller : MonoInstaller<EnergyScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Energy).WhenInjectedInto<ResourceText>();
        }
    }
}