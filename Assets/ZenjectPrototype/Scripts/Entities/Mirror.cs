using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Mirror : Entity, IReflector
    {
        private IReflector reflector;

        [Inject]
        public void Construct(IReflector reflector)
        {
            this.reflector = reflector;
        }

        public void Reflect(IMovable movable, Vector3 normal)
        {
            reflector.Reflect(movable, normal);
        }
    }
}