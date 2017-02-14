using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class LinearMovement : IMovable
    {
        public Vector3 Velocity { get; set; }

        private Transform transform;

        [Inject]
        public LinearMovement(Transform transform)
        {
            this.transform = transform;
        }

        public void Move()
        {
            transform.position += Velocity * Time.deltaTime;
        }
    }
}
