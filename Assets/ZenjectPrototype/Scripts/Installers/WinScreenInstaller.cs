using Zenject;

namespace ZenjectPrototype.Installers
{
    public class WinScreenInstaller : MonoInstaller<WinScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICondition>().FromResolveGetter<ConditionContainer>(x => x.WinCondition);
        }
    }
}
