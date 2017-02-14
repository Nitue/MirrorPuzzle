using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IMovable
    {
        Vector3 Velocity { get; set; }
        void Move();
    }
}