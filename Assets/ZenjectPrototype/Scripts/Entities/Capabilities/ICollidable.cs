using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface ICollidable
    {
        bool IsCollision(Collision collision);
    }
}
