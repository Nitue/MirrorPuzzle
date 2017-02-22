using Zenject;
using ZenjectPrototype.ResourceSystem;

namespace ZenjectPrototype.Installers
{
    public class ResourceInstaller : MonoInstaller<ResourceInstaller>
    {
        public int EnergyStock;
        public int ChargeStock;

        public override void InstallBindings()
        {
            Container.Bind<ResourceContainer>().To<ResourceContainer>().AsSingle();
            Container.Bind<IResource<int>>().WithId(ResourceContainer.Resource.Charges).To<Resource>().WithArguments(ChargeStock).WhenInjectedInto<ResourceContainer>();
            Container.Bind<IResource<int>>().WithId(ResourceContainer.Resource.Energy).To<Resource>().WithArguments(EnergyStock).WhenInjectedInto<ResourceContainer>();
        }
    }
}
