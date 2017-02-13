using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Mirror : Entity
    {
        protected void OnCollisionEnter(Collision collision)
        {
            var movable = collision.collider.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                //movable.Move(); // reflect the velocity
            }
        }
    }
}