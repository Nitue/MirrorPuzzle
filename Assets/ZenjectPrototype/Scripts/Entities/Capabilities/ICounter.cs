using System;
using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class CountUpEventArgs : EventArgs { }
    public delegate void CountUpEventHandler(object sender, CountUpEventArgs e);

    public interface ICounter
    {
        int Count { get; }
        event CountUpEventHandler OnCountUp;
    }
}