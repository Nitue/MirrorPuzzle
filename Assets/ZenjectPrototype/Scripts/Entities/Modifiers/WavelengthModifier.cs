using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities.Modifiers
{
    public class WavelengthModifier : Modifier
    {
        private IWave wave;
        private int addition;

        public int Addition
        {
            get { return addition; }
            set
            {
                if(addition != value)
                {
                    Detach();
                    addition = value;
                    Apply();
                }
            }
        }

        [Inject]
        public WavelengthModifier(IWave wave, int addition)
        {
            this.wave = wave;
            this.addition = addition;
        }

        protected override void OnApply()
        {
            wave.Wavelength += addition;
        }

        protected override void OnDetach()
        {
            wave.Wavelength -= addition;
        }

        public class Factory : Factory<IWave, int, WavelengthModifier> { }
    }
}
