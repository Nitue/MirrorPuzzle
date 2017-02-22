using Zenject;
using ZenjectPrototype.ResourceSystem;

namespace ZenjectPrototype.Installers
{
    /// <summary>
    /// Instance of this class can be used to get specific a Resource by using FromResolveGetter when binding.
    /// </summary>
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
