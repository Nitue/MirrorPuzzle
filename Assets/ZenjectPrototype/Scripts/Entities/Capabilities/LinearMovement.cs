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

        private Settings settings;

        [Inject]
        public LinearMovement(Settings settings)
        {
            this.settings = settings;
        }

        public void Move()
        {
            settings.Transform.position += Velocity * Time.deltaTime;
        }

        [Serializable]
        public class Settings
        {
            public Transform Transform;
        }
    }
}
