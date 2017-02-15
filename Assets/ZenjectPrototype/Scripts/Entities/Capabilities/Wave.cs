using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class Wave : IWave
    {
        private Settings settings;

        public int Wavelength
        {
            get
            {
                return settings.Wavelength;
            }

            set
            {
                if(value != settings.Wavelength)
                {
                    settings.Wavelength = value;
                    if (OnWavelengthChanged != null) OnWavelengthChanged(this, new WavelengthChangedEventArgs());
                }
            }
        }

        public event WavelengthChangeEventHandler OnWavelengthChanged;

        [Inject]
        public Wave(Settings settings)
        {
            this.settings = settings;
        }

        [Serializable]
        public class Settings
        {
            [Tooltip("Wavelength in nanometers.")]
            [Range(380, 750)]
            public int Wavelength;
        }
    }
}
