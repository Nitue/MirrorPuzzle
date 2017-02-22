using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Spawners;
using ZenjectPrototype.RoundSystem;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public GameObject PhotonPrefab;

        public override void InstallBindings()
        {
            // Every Class that depends directly or on an interface that 'EntityManager' and 'PhotonSpawner'
            // implements, gets the same instance (singleton) of 'EntityManager' and 'PhotonSpawner'
            Container.Bind<IInitializable>().To<GameManager>().AsSingle();
            Container.Bind<SceneEntityTracker>().AsSingle().NonLazy();
            Container.BindAllInterfacesAndSelf<EntityManager>().To<EntityManager>().AsSingle().NonLazy();
            Container.BindAllInterfacesAndSelf<PhotonSpawner>().To<PhotonSpawner>().AsSingle().NonLazy();

            // Each created Photon via the factory is created from a Prefab
            Container.BindFactory<Photon, Photon.Factory>().FromPrefab(PhotonPrefab);
        }
    }
}