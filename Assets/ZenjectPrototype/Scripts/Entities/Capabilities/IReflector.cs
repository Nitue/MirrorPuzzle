using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IReflector
    {
        void Reflect(IMovable movable, Vector3 normal);
    }
}
