using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Wall : Entity
    {
        protected void OnCollisionEnter(Collision collision)
        {
            var killable = collision.collider.gameObject.GetComponent<IKillable>();
            if(killable != null)
            {
                killable.Kill();
            }
        }
    }
}
