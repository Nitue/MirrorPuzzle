using UnityEngine;
using Zenject;
using ZenjectPrototype.Exchange;
using ZenjectPrototype.UI;

public class ExchangeItemInstaller : MonoInstaller<ExchangeItemInstaller>
{
    public GameObject ExchangeItemPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<IExchangable, ExchangeItem, ExchangeItem.Factory>().FromPrefab(ExchangeItemPrefab);
    }
}