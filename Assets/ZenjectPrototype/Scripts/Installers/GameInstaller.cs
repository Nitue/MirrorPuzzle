using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Spawners;
using ZenjectPrototype.Managers;
using ZenjectPrototype.Entities.Modifiers;
using ZenjectPrototype.GameState;
using ZenjectPrototype.UI;

namespace ZenjectPrototype.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public GameObject PhotonPrefab;
        public int EnergyStock;
        public int ChargeStock;

        public override void InstallBindings()
        {
            // Every Class that depends directly or on an interface that 'EntityManager' and 'PhotonSpawner'
            // implements, gets the same instance (singleton) of 'EntityManager' and 'PhotonSpawner'
            Container.Bind<IInitializable>().To<GameManager>().AsSingle();
            Container.Bind<SceneEntityTracker>().AsSingle().NonLazy();
            Container.BindAllInterfacesAndSelf<EntityManager>().To<EntityManager>().AsSingle().NonLazy();
            Container.BindAllInterfacesAndSelf<PhotonSpawner>().To<PhotonSpawner>().AsSingle().NonLazy();

            Container.Bind<ResourceContainer>().To<ResourceContainer>().AsSingle();
            Container.Bind<IResource<int>>().To<Resource>().WhenInjectedInto<ResourceContainer>();

            Container.Bind<ICondition>().To<WinCondition>().AsSingle().WhenInjectedInto<WinPanel>();
            Container.Bind<ICondition>().To<LoseCondition>().AsSingle().WhenInjectedInto<LosePanel>();

            // Each created Photon via the factory is created from a Prefab
            Container.BindFactory<Photon, Photon.Factory>().FromPrefab(PhotonPrefab);

            Container.BindFactory<IWave, int, WavelengthModifier, WavelengthModifier.Factory>().FromNew();

            RoundInstaller.Install(Container);
        }
    }
}