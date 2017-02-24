using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class PerfectReflector : IReflector
    {
        public void Reflect(IMovable movable, Vector3 normal)
        {
            var reflectedVelocity = Vector3.Reflect(movable.Velocity, normal);
            movable.Velocity = reflectedVelocity;
        }
    }
}
