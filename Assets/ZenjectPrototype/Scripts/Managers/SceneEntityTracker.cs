using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.Managers
{
    public class SceneEntityTracker
    {
        private IDataHolder<Entity> entityHolder;

        [Inject]
        public SceneEntityTracker(IDataHolder<Entity> entityHolder)
        {
            this.entityHolder = entityHolder;
        }

        public void Fetch()
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
                entityHolder.Add(entity);
            }
        }
    }
}
