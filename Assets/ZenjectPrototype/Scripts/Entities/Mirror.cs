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
            Debug.Log("Colliding!");
            var rotatable = collision.collider.gameObject.GetComponent<IRotatable>();
            if (rotatable != null)
            {
                var reflect = Vector3.Reflect(rotatable.Rotation, collision.contacts[0].normal);
                rotatable.Rotate(reflect);
            }
        }
    }
}