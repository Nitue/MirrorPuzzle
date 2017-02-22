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

        public override void InstallBindings()
        {
            WaveColorSettings.Wave = Receiver;
            FilterSettings.Wavelength = WaveSettings.Wavelength;

            Container.BindInstance(WaveSettings).WhenInjectedInto<Wave>();
            Container.BindInstance(WaveColorSettings).WhenInjectedInto<WaveColor>();
            Container.BindInstance(FilterSettings).WhenInjectedInto<WaveFilter>();

            Container.Bind<IFilter>().To<WaveFilter>().WhenInjectedInto<FilteredCollision>();
            Container.Bind<IWave>().To<Wave>().WhenInjectedInto<PhotonReceiver>();
            Container.Bind<ICollidable>().To<FilteredCollision>().WhenInjectedInto<PhotonReceiver>();
        }
    }
}