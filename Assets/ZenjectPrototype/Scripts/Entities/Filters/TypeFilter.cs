using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities.Filters
{
    public class TypeFilter : IFilter
    {
        private Settings settings;

        [Inject]
        public TypeFilter(Settings settings)
        {
            this.settings = settings;
        }

        public bool IsMatch(Entity target)
        {
            foreach(var ob in settings.Types)
            {
                if(target.GetType() == ob.GetType()) return true;
            }
            return false;
        }

        [Serializable]
        public class Settings
        {
            public Entity[] Types;
        }
    }
}
