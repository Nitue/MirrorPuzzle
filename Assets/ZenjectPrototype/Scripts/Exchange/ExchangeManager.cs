using System;
using System.Collections.Generic;
using System.Linq;

namespace ZenjectPrototype.Exchange
{
    public class ExchangeManager : IDataHolder<IExchangable>
    {
        private List<IExchangable> exchangables = new List<IExchangable>();

        public event AddedEventHandler<IExchangable> OnAdded;

        public void Add(IExchangable data)
        {
            if (!exchangables.Contains(data))
            {
                exchangables.Add(data);
                if (OnAdded != null) OnAdded(this, new AddedEventArgs<IExchangable>(data));
            }
        }

        public IExchangable Get(Func<IExchangable, bool> predicate)
        {
            return GetAll(predicate).First();
        }

        public IEnumerable<IExchangable> GetAll()
        {
            return exchangables;
        }

        public IEnumerable<IExchangable> GetAll(Func<IExchangable, bool> predicate)
        {
            return exchangables.Where(predicate);
        }
    }
}
