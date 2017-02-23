using System;
using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface ICollidable
    {
        event EventHandler OnValidCollision;
        event EventHandler OnInvalidCollision;
        bool IsCollision(Collision collision);
    }
}
