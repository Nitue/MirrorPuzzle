using System;

namespace ZenjectPrototype
{
    public interface ICondition
    {
        event EventHandler OnConditionMet;
    }
}
