using Zenject;
using ZenjectPrototype.ResourceSystem;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class HUDInstaller : MonoInstaller<HUDInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Charges).WhenInjectedInto<ResourceText>();
        }
    }
}