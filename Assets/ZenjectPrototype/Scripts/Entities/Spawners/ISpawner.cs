using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZenjectPrototype.Entities.Spawners
{
    public delegate void SpawnedEventHandler<in T>(object sender, T spawned) where T : Entity;

    public interface ISpawner<out T> where T : Entity
    {
        event SpawnedEventHandler<T> OnSpawned;
        T Spawn(Vector3 position);
    }
}