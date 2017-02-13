using System;
using UnityEngine;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class WavelengthChangedEventArgs : EventArgs { }
    public delegate void WavelengthChangeEventHandler(object sender, WavelengthChangedEventArgs e);

    public interface IWave
    {
        int Wavelength { get; set; }
        event WavelengthChangeEventHandler OnWavelengthChanged;
    }
}