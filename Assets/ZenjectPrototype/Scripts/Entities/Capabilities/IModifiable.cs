using System.Collections;
using ZenjectPrototype.Entities.Modifiers;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IModifiable
    {
        IEnumerable Modifiers { get; }
        void Register(Modifier modifier);
    }
}
