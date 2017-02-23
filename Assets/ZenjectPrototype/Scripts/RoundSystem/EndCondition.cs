using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype.RoundSystem
{
    /// <summary>
    /// Defines when a round ends.
    /// </summary>
    public class EndCondition : IInitializable, ICondition
    {
        private IDataHolder<Entity> entities;
        private ISpawner<Photon> photonSpawner;
        private int trackedPhotons = 0;

        public event EventHandler OnConditionMet;

        [Inject]
        public EndCondition(ISpawner<Photon> photonSpawner, IDataHolder<Entity> entities)
        {
            this.photonSpawner = photonSpawner;
            this.entities = entities;
        }

        public void Initialize()
        {
            photonSpawner.OnSpawned += PhotonSpawner_OnSpawned;
            ListenToReceivers(entities.GetAll().OfType<IReceiver<Photon>>());
        }

        private void PhotonSpawner_OnSpawned(object sender, SpawnedEventArgs e)
        {
            trackedPhotons++;
            e.Spawned.OnDestroyed += Photon_OnDestroyed;
        }

        private void ListenToReceivers(IEnumerable<IReceiver<Photon>> receivers)
        {
            foreach(var receiver in receivers)
            {
                receiver.OnReceived += Receiver_OnReceived;
            }
        }

        private void Receiver_OnReceived(object sender, ReceivedEventArgs<Photon> e)
        {
            trackedPhotons--;
            e.ReceivedObject.OnDestroyed -= Photon_OnDestroyed; // Stop listening from messing up the 'trackedPhotons' count if it is destroyed
            TryEnding();
        }

        private void Photon_OnDestroyed(Entity sender)
        {
            trackedPhotons--;
            TryEnding();
        }

        private void TryEnding()
        {
            if (trackedPhotons == 0)
            {
                if (OnConditionMet != null) OnConditionMet(this, new EventArgs());
            }
        }
    }
}
