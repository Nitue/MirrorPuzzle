using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.Installers
{
    public class ResourceContainer
    {
        public IResource<int> Charges;
        public IResource<int> Energy;

        public ResourceContainer(
            [Inject(Id = Resource.Charges)] IResource<int> charges,
            [Inject(Id = Resource.Energy)] IResource<int> energy)
        {
            Charges = charges;
            Energy = energy;
        }

        public enum Resource
        {
            Charges,
            Energy
        }
    }
}
