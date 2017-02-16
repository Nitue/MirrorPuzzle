using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool IsCollision(Collision collision)
        {
            var entity = collision.collider.GetComponent<Entity>();
            return (entity != null && filter.IsMatch(entity));
        }
    }
}
