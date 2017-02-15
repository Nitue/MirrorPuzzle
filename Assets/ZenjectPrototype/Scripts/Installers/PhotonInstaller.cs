using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class PhotonInstaller : MonoInstaller<PhotonInstaller>
    {
        public Photon Photon;
        public Rotator.Settings RotatorSettings;
        public WaveColor.Settings WaveColorSettings;
        public Wave.Settings WaveSettings;

        public override void InstallBindings()
        {
            WaveColorSettings.Wave = Photon;

            Container.BindInstance(WaveSettings).WhenInjectedInto<Wave>();
            Container.BindInstance(WaveColorSettings).WhenInjectedInto<WaveColor>();
            Container.BindInstance(RotatorSettings).WhenInjectedInto<Rotator>();
            Container.BindInstance(RotatorSettings.Transform).WhenInjectedInto<LinearMovement>();
            Container.Bind<IMovable>().To<LinearMovement>().WhenInjectedInto<Photon>();
            Container.Bind<IRotatable>().To<Rotator>().WhenInjectedInto<Photon>();
            Container.Bind<IWave>().To<Wave>().WhenInjectedInto<Photon>();
        }
    }
}