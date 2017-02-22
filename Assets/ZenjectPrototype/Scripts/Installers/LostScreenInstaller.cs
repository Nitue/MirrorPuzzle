using Zenject;

namespace ZenjectPrototype.Installers
{
    public class LostScreenInstaller : MonoInstaller<LostScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICondition>().FromResolveGetter<ConditionContainer>(x => x.LoseCondition);
        }
    }
}
