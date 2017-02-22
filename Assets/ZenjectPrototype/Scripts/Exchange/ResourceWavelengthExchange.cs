using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenjectPrototype.Entities.Modifiers;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.Exchange
{
    public class ResourceWavelengthExchange : IExchangable
    {
        private WavelengthModifier modifier;
        private IResource<int> resource;

        public ResourceWavelengthExchange(WavelengthModifier modifier, IResource<int> resource)
        {
            this.modifier = modifier;
            this.resource = resource;
        }

        public void To(int amount)
        {
            resource.Spend(amount);
            modifier.Addition += amount;
        }

        public void From(int amount)
        {
            resource.Restock(amount);
            modifier.Addition -= amount;
        }
    }
}
