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

        public override void InstallBindings()
        {
            Container.BindInstance(RotatorSettings).WhenInjectedInto<Rotator>();
            Container.Bind<IRotatable>().FromInstance(PhotonEmitter).WhenInjectedInto<MouseRotate>();
            Container.Bind<IRotatable>().To<Rotator>().WhenInjectedInto<PhotonEmitter>();
        }
    }
}