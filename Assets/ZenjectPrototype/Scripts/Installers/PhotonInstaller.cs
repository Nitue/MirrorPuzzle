using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Installers
{
    public class PhotonInstaller : MonoInstaller<PhotonInstaller>
    {
        [SerializeField]
        private Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings.Transform).WhenInjectedInto<LinearMovement>();
            Container.Bind<IMovable>().To<LinearMovement>().WhenInjectedInto<Photon>();
        }

        [Serializable]
        public class Settings
        {
            public Transform Transform;

        }
    }
}