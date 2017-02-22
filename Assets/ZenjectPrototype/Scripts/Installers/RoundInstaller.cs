using Zenject;
using ZenjectPrototype.RoundSystem;
using ZenjectPrototype.ResourceSystem;

namespace ZenjectPrototype.Installers
{
    public class RoundInstaller : MonoInstaller<RoundInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ConditionContainer>().To<ConditionContainer>().AsSingle();

            Container.BindAllInterfaces<EndCondition>().To<EndCondition>().AsSingle();
            Container.BindAllInterfaces<LoseCondition>().To<LoseCondition>().AsSingle();
            Container.BindAllInterfaces<WinCondition>().To<WinCondition>().AsSingle();

            Container.BindAllInterfaces<WinCondition>().WithId(ConditionContainer.Condition.Win).To<WinCondition>().AsSingle();
            Container.BindAllInterfaces<LoseCondition>().WithId(ConditionContainer.Condition.Lose).To<LoseCondition>().AsSingle();

            Container.BindAllInterfaces<LevelRoundManager>().To<LevelRoundManager>().AsSingle();
            Container.BindAllInterfaces<EmitterTrigger>().To<EmitterTrigger>().AsSingle();

            Container.Bind<ICondition>().To<EndCondition>().AsSingle().WhenInjectedInto<LevelRoundManager>();
            Container.Bind<IResource<int>>().FromResolveGetter<ResourceContainer>(x => x.Charges).WhenInjectedInto<LevelRoundManager>();
        }
    }
}