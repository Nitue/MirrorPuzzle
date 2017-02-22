using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.Entities.Modifiers;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.UI
{
    public class EmitterItem : MonoBehaviour
    {
        private WavelengthModifier wavelengthModifier;

        [Inject]
        public void Construct(WavelengthModifier wavelengthModifier)
        {
            this.wavelengthModifier = wavelengthModifier;
        }

        public void ChangeValue()
        {
            //wavelengthModifier.Addition =  Mathf.RoundToInt(slider.value);
        }

        public class Factory : Factory<WavelengthModifier, EmitterItem> { }
    }
}
