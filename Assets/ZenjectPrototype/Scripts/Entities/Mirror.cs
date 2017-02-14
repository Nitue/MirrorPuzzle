using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Mirror : Entity
    {
        public void OnCollisionEnter(Collision collision)
        {
            var movable = collision.collider.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                var reflectedVelocity = Vector3.Reflect(movable.Velocity, collision.contacts[0].normal);
                movable.Velocity = reflectedVelocity;
            }
        }
    }
}