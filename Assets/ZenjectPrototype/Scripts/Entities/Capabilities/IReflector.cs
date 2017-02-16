using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public interface IReflector
    {
        void Reflect(IMovable movable, Vector3 normal);
    }
}
