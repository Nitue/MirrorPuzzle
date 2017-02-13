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
        public override void InstallBindings()
        {
            Container.Bind<IRotatable>().To<Rotator>().AsSingle().WhenInjectedInto<PhotonEmitter>();
        }

        [Serializable]
        public class Settings
        {
            
        }
    }
}