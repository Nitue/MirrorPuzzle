using System;
using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class ReceivedEventArgs : EventArgs { }
    public delegate void ReceivedEventHandler(object sender, ReceivedEventArgs e);

    public interface IReceiver
    {
        int Received { get; }
        event ReceivedEventHandler OnReceived;
    }
}