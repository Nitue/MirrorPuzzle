using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities.Filters
{
    public class TypeFilter : IFilter
    {
        public object[] Types;
        public bool IsMatch(object target)
        {
            foreach(var ob in Types)
            {
                if(target.GetType() == ob.GetType()) return true;
            }
            return false;
        }
    }
}
