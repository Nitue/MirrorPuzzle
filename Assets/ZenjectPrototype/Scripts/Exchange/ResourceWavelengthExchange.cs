using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;
using ZenjectPrototype.ResourceSystem;

namespace ZenjectPrototype.Exchange
{
    /// <summary>
    /// Exchanges given Resource to Wavelength.
    /// </summary>
    public class ResourceWavelengthExchange : IExchangable
    {
        private IWave wave;
        private IResource<int> resource;

        [Inject]
        public ResourceWavelengthExchange(IWave wave, IResource<int> resource)
        {
            this.wave = wave;
            this.resource = resource;
        }

        public bool Exchange(int amount)
        {
            // Direction of exchange is detemined by +/-
            if (amount > 0) return To(amount);
            else if (amount < 0) return From(Mathf.Abs(amount));
            return false;
        }

        private bool To(int amount)
        {
            if(resource.Spend(amount))
            {
                wave.Wavelength -= amount;
                return true;
            }
            return false;
        }

        private bool From(int amount)
        {
            resource.Restock(amount);
            wave.Wavelength += amount;
            return true;
        }

        public class Factory : Factory<IWave, ResourceWavelengthExchange> { }
    }
}
