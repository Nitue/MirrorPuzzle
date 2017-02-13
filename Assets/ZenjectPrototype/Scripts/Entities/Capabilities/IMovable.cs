using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IMovable
    {
        float Speed { get; set; }
        void Move(Vector3 direction);
    }
}