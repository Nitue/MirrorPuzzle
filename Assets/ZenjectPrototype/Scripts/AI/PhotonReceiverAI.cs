using System;
using UnityEngine;
using ZenjectPrototype.Entities;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Filters;

namespace ZenjectPrototype.AI
{
    public class PhotonReceiverAI : AI
    {
        [SerializeField]
        private PhotonReceiver photonReceiver;

        protected override void Update()
        {
            // Not actually needed... Think about solution for this. Empty methods are no good.
            // Possible solutions:
            // - remove AI base class
            // - instead of AI base class, use interfaces for different kind of AI behaviour
        }

        protected void OnCollisionEnter(Collision collision)
        {
            var killable = collision.collider.GetComponent<IKillable>();
            if (photonReceiver.IsCollision(collision))
            {
                photonReceiver.CountUp();
            }

            killable.Kill();
        }
    }
}
