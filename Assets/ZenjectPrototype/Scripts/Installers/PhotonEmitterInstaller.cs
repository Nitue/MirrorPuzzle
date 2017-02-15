using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Spawners;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class PhotonEmitterInstaller : MonoInstaller<PhotonEmitterInstaller>
    {
        public PhotonEmitter PhotonEmitter;
        public Rotator.Settings RotatorSettings;
        public WaveColor.Settings WaveColorSettings;
        public Wave.Settings WaveSettings;

        public override void InstallBindings()
        {
            WaveColorSettings.Wave = PhotonEmitter;

            Container.BindInstance(RotatorSettings).WhenInjectedInto<Rotator>();
            Container.BindInstance(WaveColorSettings).WhenInjectedInto<WaveColor>();
            Container.BindInstance(WaveSettings).WhenInjectedInto<Wave>();
            Container.Bind<IRotatable>().FromInstance(PhotonEmitter).WhenInjectedInto<MouseRotate>();
            Container.Bind<IRotatable>().To<Rotator>().WhenInjectedInto<PhotonEmitter>();
            Container.Bind<IWave>().To<Wave>().WhenInjectedInto<PhotonEmitter>();
        }
    }
}