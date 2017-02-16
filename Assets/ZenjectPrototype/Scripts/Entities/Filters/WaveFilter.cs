using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities.Filters
{
    public class WaveFilter : IFilter
    {
        private Settings settings;

        private int WavelengthMin
        {
            get { return settings.Wavelength - settings.WavelengthErrorMargin; }
        }

        private int WavelengthMax
        {
            get { return settings.Wavelength + settings.WavelengthErrorMargin; }
        }

        public WaveFilter(Settings settings)
        {
            this.settings = settings;
        }

        public bool IsMatch(Entity target)
        {
            if(target is IWave)
            {
                var wave = (IWave)target;
                return (wave.Wavelength >= WavelengthMin && wave.Wavelength <= WavelengthMax);
            }
            return false;
        }

        [Serializable]
        public class Settings
        {
            public int Wavelength;
            public int WavelengthErrorMargin;
        }
    }
}
