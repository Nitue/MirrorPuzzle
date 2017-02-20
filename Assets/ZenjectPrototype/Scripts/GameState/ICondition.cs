using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenjectPrototype.GameState
{
    public interface ICondition
    {
        event EventHandler OnConditionMet;
    }
}
