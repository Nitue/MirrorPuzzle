using UnityEngine;
using Zenject;
using ZenjectPrototype.Managers;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class EnergyTextInstaller : MonoInstaller<EnergyTextInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Energy);
        }
    }
}