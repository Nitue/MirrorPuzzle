using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Installers
{
    public class PhotonInstaller : MonoInstaller<PhotonInstaller>
    {
        public Rotator.Settings RotatorSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(RotatorSettings).WhenInjectedInto<Rotator>();
            Container.BindInstance(RotatorSettings.Transform).WhenInjectedInto<LinearMovement>();
            Container.Bind<IMovable>().To<LinearMovement>().WhenInjectedInto<Photon>();
            Container.Bind<IRotatable>().To<Rotator>().WhenInjectedInto<Photon>();
        }
    }
}