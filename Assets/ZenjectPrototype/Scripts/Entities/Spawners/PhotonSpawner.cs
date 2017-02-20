using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Spawners
{
    public class PhotonSpawner : ISpawner<Photon>
    {
        public event SpawnedEventHandler OnSpawned;

        private Photon.Factory factory;

        [Inject]
        public PhotonSpawner(Photon.Factory factory)
        {
            this.factory = factory;
        }

        public Photon Spawn(Vector3 position)
        {
            var spawned = factory.Create();
            spawned.transform.position = position;
            if(OnSpawned != null) OnSpawned(this, new SpawnedEventArgs(spawned));
            return spawned;
        }
    }
}
