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
            // Here we bind ResourceContainer as singleton
            Container.Bind<ResourceContainer>().To<ResourceContainer>().AsSingle();

            // And here we Resource instance to the container.
            // Other bindings can use 'FromResolveGetter' on 'ResourceContainer' to get a instance for 'Charges' or 'Energy'
            Container.Bind<IResource<int>>().WithId(ResourceContainer.Resource.Charges).To<Resource>().WithArguments(ChargeStock).WhenInjectedInto<ResourceContainer>();
            Container.Bind<IResource<int>>().WithId(ResourceContainer.Resource.Energy).To<Resource>().WithArguments(EnergyStock).WhenInjectedInto<ResourceContainer>();
        }
    }
}
