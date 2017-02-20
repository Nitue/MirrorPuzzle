using System;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype.GameState
{
    public class EndCondition : IInitializable, ICondition
    {
        private ISpawner<Photon> photonSpawner;
        private int trackedPhotons = 0;

        public event EventHandler OnConditionMet;

        [Inject]
        public EndCondition(ISpawner<Photon> photonSpawner)
        {
            this.photonSpawner = photonSpawner;
        }

        public void Initialize()
        {
            photonSpawner.OnSpawned += PhotonSpawner_OnSpawned;
        }

        private void PhotonSpawner_OnSpawned(object sender, SpawnedEventArgs e)
        {
            trackedPhotons++;
            e.Spawned.OnDestroyed += Photon_OnDestroyed;
        }

        private void Photon_OnDestroyed(Entity sender)
        {
            trackedPhotons--;

            if (trackedPhotons == 0)
            {
                if (OnConditionMet != null) OnConditionMet(this, new EventArgs());
            }
        }
    }
}
