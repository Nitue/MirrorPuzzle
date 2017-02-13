using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IRotatable
    {
        void Rotate(Vector3 amount);
        Vector3 Rotation { get; set; }
    }
}