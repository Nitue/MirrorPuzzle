using Zenject;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype.Entities
{
    /// <summary>
    /// Adds spawners to EntityManager which it will listen for new Entities.
    /// </summary>
    public class EntityManagerInitializer : IInitializable
    {
        private EntityManager entityManager;
        private PhotonSpawner photonSpawner;

        [Inject]
        public EntityManagerInitializer(EntityManager entityManager, PhotonSpawner photonSpawner)
        {
            this.entityManager = entityManager;
            this.photonSpawner = photonSpawner;
        }

        public void Initialize()
        {
            entityManager.AddSpawner(photonSpawner);
        }
    }
}