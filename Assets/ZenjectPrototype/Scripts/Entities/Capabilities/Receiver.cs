using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class Receiver : IReceiver<Photon>
    {
        public IEnumerable<Photon> ReceivedObjects
        {
            get { return receivedObjects; }
        }

        public bool HasReceivedAnything
        {
            get { return (receivedObjects.Count > 0); }
        }

        public event ReceivedEventHandler<Photon> OnReceived;

        private List<Photon> receivedObjects = new List<Photon>();
        private Settings settings;

        [Inject]
        public Receiver(Settings settings)
        {
            this.settings = settings;
        }

        public void Receive(Photon entity)
        {
            if(receivedObjects.Count == 0)
            {
                entity.OnDestroyed += Entity_OnDestroyed;
                entity.transform.position = settings.Transform.position + settings.PositionOffset;
                entity.Velocity = Vector3.zero;
                receivedObjects.Add(entity);
                if (OnReceived != null) OnReceived.Invoke(this, new ReceivedEventArgs<Photon>(entity));
            }
            else
            {
                entity.Kill();
            }
        }

        private void Entity_OnDestroyed(Entity sender)
        {
            receivedObjects.Remove((Photon)sender);
        }

        public void Release()
        {
            foreach(var entity in receivedObjects)
            {
                entity.Kill();
            }
        }

        [Serializable]
        public class Settings
        {
            public Transform Transform;
            public Vector3 PositionOffset;
        }
    }
}
