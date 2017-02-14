using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IRotatable
    {
        void Rotate(Vector3 eulerAngles);
        void LookAt(Vector3 position);
        Vector3 Rotation { get; set; }
    }
}