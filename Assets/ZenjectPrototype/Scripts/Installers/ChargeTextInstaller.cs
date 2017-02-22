using UnityEngine;
using Zenject;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.Installers
{
    public class ChargeTextInstaller : MonoInstaller<ChargeTextInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Charges);
        }
    }
}