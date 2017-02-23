using System;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities
{
    /// <summary>
    /// Adds all Entities placed in editor-time to manager.
    /// </summary>
    public class SceneEntityTracker : IInitializable
    {
        private IDataHolder<Entity> entities;

        [Inject]
        public SceneEntityTracker(IDataHolder<Entity> entityHolder)
        {
            this.entities = entityHolder;
        }

        public void Initialize()
        {
            SaveEntities(GetSceneEntities());
        }

        private Entity[] GetSceneEntities()
        {
            return GameObject.FindObjectsOfType<Entity>();
        }

        private void SaveEntities(Entity[] entities)
        {
            foreach(var entity in entities)
            {
                this.entities.Add(entity);
            }
        }
    }
}
