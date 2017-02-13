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
        public float Speed { get; set; }

        private Transform transform;

        [Inject]
        public LinearMovement(Transform transform)
        {
            this.transform = transform;
        }

        public void Move(Vector3 direction)
        {
            transform.position += Speed * direction.normalized * Time.deltaTime;
        }
    }
}
