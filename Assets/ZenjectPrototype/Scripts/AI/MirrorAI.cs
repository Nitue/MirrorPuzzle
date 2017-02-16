using System;
using UnityEngine;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.AI
{
    public class MirrorAI : AI
    {
        [SerializeField]
        private Mirror mirror;

        protected override void Update()
        {
            // Not actually needed... Think about solution for this. Empty methods are no good
        }

        protected void OnCollisionEnter(Collision collision)
        {
            var movable = collision.collider.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                mirror.Reflect(movable, collision.contacts[0].normal);
            }
        }
    }
}
