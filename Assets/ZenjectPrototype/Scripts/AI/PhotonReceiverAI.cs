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
            //throw new NotImplementedException();
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
