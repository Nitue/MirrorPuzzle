using Zenject;
using ZenjectPrototype.GameState;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.Installers
{
    public class RoundInstaller : Installer<RoundInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindAllInterfaces<LevelRoundManager>().To<LevelRoundManager>().AsSingle();
            Container.BindAllInterfaces<EmitterTrigger>().To<EmitterTrigger>().AsSingle();
            Container.BindAllInterfaces<EndCondition>().To<EndCondition>().AsSingle();
            Container.BindAllInterfaces<WinCondition>().To<WinCondition>().AsSingle();
            Container.BindAllInterfaces<LoseCondition>().To<LoseCondition>().AsSingle();

            Container.Bind<ICondition>().To<EndCondition>().AsSingle().WhenInjectedInto<LevelRoundManager>();
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Charges).WhenInjectedInto<LevelRoundManager>();
        }
    }
}