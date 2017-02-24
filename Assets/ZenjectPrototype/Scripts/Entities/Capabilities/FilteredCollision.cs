using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Filters;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class FilteredCollision : ICollidable
    {
        private IFilter filter;

        [Inject]
        public FilteredCollision(IFilter filter)
        {
            this.filter = filter;
        }

        public event EventHandler OnInvalidCollision;
        public event EventHandler OnValidCollision;

        public bool IsCollision(Collision collision)
        {
            var entity = collision.collider.GetComponent<Entity>();
            if(entity != null && filter.IsMatch(entity))
            {
                if (OnValidCollision != null) OnValidCollision.Invoke(this, new EventArgs());
                return true;
            }
            else
            {
                if (OnInvalidCollision != null) OnInvalidCollision.Invoke(this, new EventArgs());
                return false;
            }
        }
    }
}
