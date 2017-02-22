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

        [Inject]
        public ResourceContainer(IResource<int> charges, IResource<int> energy)
        {
            Charges = charges;
            Energy = energy;
        }
    }
}
