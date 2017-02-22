using System;
using System.Collections.Generic;
using System.Linq;
using ZenjectPrototype.Entities.Spawners;

namespace ZenjectPrototype.Entities
{
    public class EntityManager : IDataHolder<Entity>
    {
        private readonly List<Entity> entities = new List<Entity>();

        public event AddedEventHandler<Entity> OnAdded;

        public void AddSpawner(ISpawner<Entity> spawner)
        {
            spawner.OnSpawned += Spawner_OnSpawned;
        }

        private void Spawner_OnSpawned(object sender, SpawnedEventArgs e)
        {
            Add(e.Spawned);
        }

        public void Add(Entity data)
        {
            if (!entities.Contains(data))
            {
                data.OnDestroyed += Data_OnDestroyed;
                entities.Add(data);
                if(OnAdded != null) OnAdded.Invoke(this, new AddedEventArgs<Entity>(data));
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
