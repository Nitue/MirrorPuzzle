using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype
{
    public class GameManager : IInitializable
    {
        private SceneEntityTracker sceneEntityTracker;
        private EntityManager entityManager;
        private PhotonSpawner photonSpawner;

        [Inject]
        public GameManager(EntityManager entityManager, SceneEntityTracker entityTracker, PhotonSpawner photonSpawner)
        {
            this.sceneEntityTracker = entityTracker;
            this.entityManager = entityManager;
            this.photonSpawner = photonSpawner;
        }

        public void Initialize()
        {
            entityManager.AddSpawner(photonSpawner);
            sceneEntityTracker.Fetch();
        }
    }
}