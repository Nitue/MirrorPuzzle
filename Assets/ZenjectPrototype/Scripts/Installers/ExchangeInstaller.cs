using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Exchange;
using ZenjectPrototype.ResourceSystem;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class ExchangeInstaller : MonoInstaller<ExchangeInstaller>
    {
        public GameObject ExchangeItemPrefab;

        public override void InstallBindings()
        {
            Container.BindAllInterfacesAndSelf<ExchangeManager>().To<ExchangeManager>().AsSingle();
            Container.BindAllInterfacesAndSelf<ExchangeInitializer>().To<ExchangeInitializer>().AsSingle();

            // Here we use the 'ResourceContainer' to set 'ResourceWavelengthExchange' to use the 'Energy' resource
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Energy).WhenInjectedInto<ResourceWavelengthExchange>();

            // Factory bindings with two parameters
            Container.BindFactory<IWave, ResourceWavelengthExchange, ResourceWavelengthExchange.Factory>().FromNew();
            Container.BindFactory<IExchangable, ExchangeItem, ExchangeItem.Factory>().FromPrefab(ExchangeItemPrefab);
        }
    }
}