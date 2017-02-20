using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZenjectPrototype.Entities.Spawners
{
    public delegate void SpawnedEventHandler(object sender, SpawnedEventArgs e);
    public class SpawnedEventArgs
    {
        public readonly Entity Spawned;
        public SpawnedEventArgs(Entity spawned)
        {
            Spawned = spawned;
        }
    }

    public interface ISpawner<out T> where T : Entity
    {
        event SpawnedEventHandler OnSpawned;
        T Spawn(Vector3 position);
    }
}