using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.Managers
{
    public class EditorEntityManager
    {
        private IDataHolder<Entity> entityHolder;

        [Inject]
        public EditorEntityManager(IDataHolder<Entity> entityHolder)
        {
            this.entityHolder = entityHolder;
        }

        public void Update()
        {
            SaveEntities(GetEntities());
        }

        private Entity[] GetEntities()
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
