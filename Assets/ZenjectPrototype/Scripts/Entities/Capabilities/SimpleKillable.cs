using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class SimpleKillable : IKillable
    {
        private GameObject gameObject;

        [Inject]
        public SimpleKillable(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Kill()
        {
            GameObject.Destroy(gameObject);
        }
    }
}
