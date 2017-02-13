using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenjectPrototype.Entities.Filters
{
    public interface IFilter
    {
        bool IsMatch(object target);
    }
}
