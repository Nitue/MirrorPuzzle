using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Spawners;
using UnityEngine;

namespace ZenjectPrototype.Managers
{
    public class EntityManager : IDataHolder<Entity>
    {
        private readonly List<Entity> entities = new List<Entity>();

        public void AddSpawner(ISpawner<Entity> spawner)
        {
            spawner.OnSpawned += Spawner_OnSpawned;
        }

        private void Spawner_OnSpawned(object sender, Entity spawned)
        {
            Add(spawned);
        }

        public void Add(Entity data)
        {
            if (!entities.Contains(data))
            {
                data.OnDestroyed += Data_OnDestroyed;
                entities.Add(data);
            }
        }

        private void Data_OnDestroyed(Entity sender)
        {
            entities.Remove(sender);
        }

        public Entity Get(Func<Entity, bool> predicate)
        {
            return GetAll(predicate).First();
        }

        public IEnumerable<Entity> GetAll()
        {
            return entities;
        }

        public IEnumerable<Entity> GetAll(Func<Entity, bool> predicate)
        {
            return entities.Where(predicate);
        }
    }
}
