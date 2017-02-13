using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype.Installers
{
    public class PhotonEmitterInstaller : MonoInstaller<PhotonEmitterInstaller>
    {
        [SerializeField]
        private Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings.Transform).WhenInjectedInto<Rotator>();
            Container.BindInstance(settings.RotateStep).WhenInjectedInto<Rotator>();
            Container.Bind<IRotatable>().To<Rotator>().WhenInjectedInto<PhotonEmitter>();
        }

        [Serializable]
        public class Settings
        {
            public Transform Transform;
            public float RotateStep;
        }
    }
}