using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Filters;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installer
{
    public class PhotonReceiverInstaller : MonoInstaller<PhotonReceiverInstaller>
    {
        public PhotonReceiver Receiver;
        public WaveColor.Settings WaveColorSettings;
        public Wave.Settings WaveSettings;
        public WaveFilter.Settings FilterSettings;
        public Receiver.Settings ReceiverSettings;

        public override void InstallBindings()
        {
            FilterSettings.Wavelength = WaveSettings.Wavelength;

            Container.BindInstance(WaveSettings).WhenInjectedInto<Wave>();
            Container.BindInstance(WaveColorSettings).WhenInjectedInto<WaveColor>();
            Container.Bind<IWave>().FromInstance(Receiver).WhenInjectedInto<WaveColor>();
            Container.BindInstance(FilterSettings).WhenInjectedInto<WaveFilter>();
            Container.BindInstance(ReceiverSettings).WhenInjectedInto<Receiver>();

            Container.Bind<IFilter>().To<WaveFilter>().WhenInjectedInto<FilteredCollision>();
            Container.Bind<IReceiver<Photon>>().To<Receiver>().WhenInjectedInto<PhotonReceiver>();
            Container.Bind<IWave>().To<Wave>().WhenInjectedInto<PhotonReceiver>();
            Container.Bind<ICollidable>().To<FilteredCollision>().WhenInjectedInto<PhotonReceiver>();
            Container.Bind<ICollidable>().FromInstance(Receiver).WhenInjectedInto<Splatter>();
        }
    }
}