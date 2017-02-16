using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

public class MirrorInstaller : MonoInstaller<MirrorInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IReflector>().To<PerfectReflector>().WhenInjectedInto<Mirror>();
    }
}