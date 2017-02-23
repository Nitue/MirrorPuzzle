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
            // These two do some preparations before the game can start
            Container.BindAllInterfacesAndSelf<SceneEntityTracker>().To<SceneEntityTracker>().AsSingle();
            Container.BindAllInterfacesAndSelf<EntityManagerInitializer>().To<EntityManagerInitializer>().AsSingle();

            // 'BindAllInterfacesAndSelf' basically mean: anything that depends on 'EntityManager'
            // or on one of the interfaces that 'EntityManager' implements
            // will get an instance of 'EntityManager' to satisfy that dependency.
            // Additionally, 'AsSingle' will make every dependency injected with the same instance
            Container.BindAllInterfacesAndSelf<EntityManager>().To<EntityManager>().AsSingle();
            Container.BindAllInterfacesAndSelf<PhotonSpawner>().To<PhotonSpawner>().AsSingle();

            // Each created Photon via the factory is created from a Prefab
            // To use the factory, class can depend on 'Photon.Factory'
            Container.BindFactory<Photon, Photon.Factory>().FromPrefab(PhotonPrefab);
        }
    }
}