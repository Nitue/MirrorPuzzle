using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class ReceivedEventArgs<T>
    {
        public readonly T ReceivedObject;
        public ReceivedEventArgs(T receivedObject)
        {
            ReceivedObject = receivedObject;
        }
    }
    public delegate void ReceivedEventHandler<T>(object sender, ReceivedEventArgs<T> e);

    public interface IReceiver<T> where T : Entity
    {
        IEnumerable<T> ReceivedObjects { get; }
        event ReceivedEventHandler<T> OnReceived;
        bool HasReceivedAnything { get; }
        void Receive(T entity);
        void Release();
    }
}