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
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Energy).WhenInjectedInto<ResourceWavelengthExchange>();

            Container.BindFactory<IWave, ResourceWavelengthExchange, ResourceWavelengthExchange.Factory>().FromNew();
            Container.BindFactory<IExchangable, ExchangeItem, ExchangeItem.Factory>().FromPrefab(ExchangeItemPrefab);
        }
    }
}