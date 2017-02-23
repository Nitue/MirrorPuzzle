using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class PhotonInstaller : MonoInstaller<PhotonInstaller>
    {
        public Photon Photon;
        public LinearMovement.Settings MovementSettings;
        public Rotator.Settings RotatorSettings;
        public WaveColor.Settings WaveColorSettings;
        public Wave.Settings WaveSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(WaveSettings).WhenInjectedInto<Wave>();
            Container.BindInstance(WaveColorSettings).WhenInjectedInto<WaveColor>();
            Container.Bind<IWave>().FromInstance(Photon).WhenInjectedInto<WaveColor>();
            Container.BindInstance(Photon.gameObject).WhenInjectedInto<SimpleKillable>();
            Container.BindInstance(RotatorSettings).WhenInjectedInto<Rotator>();
            Container.BindInstance(MovementSettings).WhenInjectedInto<LinearMovement>();
            Container.Bind<IMovable>().To<LinearMovement>().WhenInjectedInto<Photon>();
            Container.Bind<IRotatable>().To<Rotator>().WhenInjectedInto<Photon>();
            Container.Bind<IWave>().To<Wave>().WhenInjectedInto<Photon>();
            Container.Bind<IKillable>().To<SimpleKillable>().WhenInjectedInto<Photon>();
        }
    }
}