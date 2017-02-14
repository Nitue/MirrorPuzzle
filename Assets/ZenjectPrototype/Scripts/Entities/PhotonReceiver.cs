using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenjectPrototype.Entities.Filters;
using ZenjectPrototype.Entities.Capabilities;
using Zenject;

namespace ZenjectPrototype.Entities
{
    public class PhotonReceiver : Entity, ICounter
    {
        public int Count { get; private set; }

        public event CountUpEventHandler OnCountUp;

        private IFilter receiverTypes;

        //[Inject]
        public void Construct(IFilter receiverTypes)
        {
            this.receiverTypes = receiverTypes;
        }

        protected void OnCollisionEnter(Collision collision)
        {
            var other = collision.collider.gameObject.GetComponent<Entity>();
            if (receiverTypes.IsMatch(other))
            {
                CountUp();
            }
        }

        private void CountUp()
        {
            Count++;
            if (OnCountUp != null) OnCountUp(this, new CountUpEventArgs());
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}
